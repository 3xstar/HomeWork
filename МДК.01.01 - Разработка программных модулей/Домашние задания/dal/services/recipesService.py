import sys
import os
sys.path.append('c:/VSCODE/postgresql/dao')
from ui.db import get_conn
from sqlalchemy import text

class RecipeRepository:
    def get_all(self):
        engine = get_conn()
        with engine.connect() as conn:
            result = conn.execute(text('SELECT * FROM recipes.recipes'))
            rows = result.fetchall()
        return rows
    
    def add(self, name, category, level, description):
        engine = get_conn()
        with engine.connect() as conn:
            try:
                # Проверяем существование категории
                result = conn.execute(
                    text('SELECT id FROM categories WHERE name = :category'),
                    {'category': category}
                )
                category_row = result.fetchone()
                
                if not category_row:
                    raise ValueError(f"Категория '{category}' не найдена")
                
                category_id = category_row[0]
                
                conn.execute(
                    text('''
                        INSERT INTO recipes.recipes (name, category_id, level, description) 
                        VALUES (:name, :category_id, :level, :description)
                    '''),
                    {'name': name, 'category_id': category_id, 'level': level, 'description': description}
                )
                conn.commit()
            except Exception as e:
                conn.rollback()
                print(f"Ошибка: {e}")
                raise
    
    def edit(self, id, name, category, level, description):
        engine = get_conn()
        with engine.connect() as conn:
            try:
                # Проверяем существование категории
                result = conn.execute(
                    text('SELECT id FROM categories WHERE name = :category'),
                    {'category': category}
                )
                category_row = result.fetchone()
                
                if not category_row:
                    raise ValueError(f"Категория '{category}' не найдена")
                
                category_id = category_row[0]
                
                conn.execute(
                    text('''
                        UPDATE recipes.recipes 
                        SET name = :name, category_id = :category_id, level = :level, description = :description 
                        WHERE id = :id
                    '''),
                    {'name': name, 'category_id': category_id, 'level': level, 
                     'description': description, 'id': id}
                )
                conn.commit()
            except Exception as e:
                conn.rollback()
                print(f"Ошибка: {e}")
                raise

    def drop(self, id):
        engine = get_conn()
        with engine.connect() as conn:
            try:
                conn.execute(
                    text('DELETE FROM recipes.recipes WHERE id = :id'),
                    {'id': id}
                )
                conn.commit()
            except Exception as e:
                conn.rollback()
                print(f"Ошибка: {e}")
                raise

    def get_by_category(self, category):
        engine = get_conn()
        with engine.connect() as conn:
            result = conn.execute(
                text('''
                    SELECT r.* FROM recipes.recipes r
                    JOIN categories c ON r.category_id = c.id
                    WHERE c.name = :category
                '''),
                {'category': category}
            )
            rows = result.fetchall()
            return rows