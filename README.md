[![License](https://img.shields.io/github/license/it-beard/bloggers-cms)](https://github.com/it-beard/bloggers-cms/blob/develop/LICENSE)
[![Stars](https://img.shields.io/github/stars/it-beard/bloggers-cms)](https://github.com/it-beard/bloggers-cms/stargazers)
[![Issues](https://img.shields.io/github/issues/it-beard/bloggers-cms)](https://github.com/it-beard/bloggers-cms/issues)

[![Deploy apps to Production](https://github.com/itbeard/bloggers-cms/actions/workflows/deployment-prod-action.yml/badge.svg?branch=main)](https://github.com/itbeard/bloggers-cms/actions/workflows/deployment-prod-action.yml)

**Bloggers CMS** - это система управления контентом, разрабатываемая специально под задачи блогеров. Платформа создается как часть экосистемы вокруг проекта ["АйТиБорода"](https://itbeard.com).   
Разрабатывается на базе **.NET 6** и **Blazor**

Платформа позволяет блогкрам aka Брендам вести учёт:
- Контента
- Участников контента
- Клиентов
- Доходов и расходов
- Подарков и конкурсов

Кроме того, CMS имеет: 
- Систему авторизации на базе Auth0
- Гибкую систему внутренних настроек "на лету"
- Множество фильтров для сущностей
- Возможность работать с несколькими Брендами в рамках одного интерфейса

#Настройка и запуст
1. [Подготовьте SQL-подобную базу данных](https://github.com/it-beard/bloggers-cms/wiki/how-to-create-db)
2. [Настройте аутентификацию через Auth0](https://github.com/it-beard/bloggers-cms/wiki/Authorisation-configuration)
3. Запустите проекты Pds.Api (бэкенд-часть CMS) и Pds.Web (фронтенд-часть CMS)
Миграция база и заполнение её начальными данными произайдут автоматически при первом запуске бэкенда (Pds.Api)

# Ссылки
Wiki проекта: https://github.com/it-beard/bloggers-cms/wiki  
Kanban-доска: https://github.com/it-beard/bloggers-cms/projects/1

# Общение
Всё общение с контрибьюторами проекту ведется на discord-сервере "[Родная Айтишка](https://discord.gg/it)", канал `#bloggers-cms`

# Лицензия

Apache License 2.0, подробнее тут [LICENSE](LICENSE).
