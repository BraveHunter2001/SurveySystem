﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class initData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("""
                INSERT INTO "Surveys" ("Name", "Description") VALUES
                ('Customer Satisfaction', 'Survey about customer experience and satisfaction');

                INSERT INTO "Questions" ("Title", "SurveyId", "NextQuestionId") VALUES
                ('Как бы вы оценили ваш общий опыт с нашим продуктом?', 1, 2),
                ('Насколько вероятно, что вы порекомендуете нас друзьям или коллегам?', 1, 3),
                ('Были ли у вас проблемы при использовании нашего продукта?', 1, 4),
                ('Что вам больше всего понравилось в нашем продукте?', 1, 5),
                ('Как мы можем улучшить наш сервис?', 1, NULL);

                INSERT INTO "Answers" ("Title", "QuestionId") VALUES
                -- Вопрос 1: Как бы вы оценили ваш общий опыт с нашим продуктом?
                ('Отлично', 1),
                ('Хорошо', 1),
                ('Удовлетворительно', 1),
                ('Плохо', 1),
                ('Очень плохо', 1),

                -- Вопрос 2: Насколько вероятно, что вы порекомендуете нас друзьям или коллегам?
                ('Определенно порекомендую', 2),
                ('Скорее порекомендую', 2),
                ('Не уверен', 2),
                ('Скорее не порекомендую', 2),
                ('Совсем не порекомендую', 2),

                -- Вопрос 3: Были ли у вас проблемы при использовании нашего продукта?
                ('Нет, всё отлично', 3),
                ('Были незначительные проблемы', 3),
                ('Были заметные сложности', 3),
                ('Было трудно использовать', 3),
                ('Я не смог воспользоваться продуктом', 3),

                -- Вопрос 4: Что вам больше всего понравилось в нашем продукте?
                ('Простота использования', 4),
                ('Дизайн и внешний вид', 4),
                ('Функциональность', 4),
                ('Цена и качество', 4),
                ('Поддержка клиентов', 4),

                -- Вопрос 5: Как мы можем улучшить наш сервис?
                ('Улучшить поддержку клиентов', 5),
                ('Добавить больше функций', 5),
                ('Снизить цену', 5),
                ('Упростить интерфейс', 5),
                ('Улучшить производительность', 5);
                
                -- тестовое интерьвю
                INSERT INTO "Interviews" ("SurveyId", "CurrentQuestionId") VALUES
                (1, 1);

                """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
