[![License](https://img.shields.io/github/license/it-beard/bloggers-cms)](https://github.com/it-beard/bloggers-cms/blob/develop/LICENSE)
[![Stars](https://img.shields.io/github/stars/it-beard/bloggers-cms)](https://github.com/it-beard/bloggers-cms/stargazers)
[![Issues](https://img.shields.io/github/issues/it-beard/bloggers-cms)](https://github.com/it-beard/bloggers-cms/issues)

[![Deploy apps to Production](https://github.com/itbeard/bloggers-cms/actions/workflows/deployment-prod-action.yml/badge.svg?branch=main)](https://github.com/itbeard/bloggers-cms/actions/workflows/deployment-prod-action.yml)

**Bloggers CMS** - это система управления контентом, разрабатываемая специально под задачи блогеров. Платформа создается как часть экосистемы вокруг проекта ["АйТиБорода"](https://itbeard.com).   
Разрабатывается на базе **.NET 7** и **Blazor**

Платформа позволяет блогерам (они же "Бренды") вести учёт:
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

<img src="https://github.com/it-beard/bloggers-cms/blob/develop/.github/readme-images/1.png" title="Дашборд" width="800" />

<img src="https://github.com/it-beard/bloggers-cms/blob/develop/.github/readme-images/2.png" title="Список контента" width="800" />

<img src="https://github.com/it-beard/bloggers-cms/blob/develop/.github/readme-images/3.png" title="Настройки" width="800" />

# Настройка и запуск
1. [Подготовьте SQL-подобную базу данных](https://github.com/it-beard/bloggers-cms/wiki/how-to-create-db)
2. [Настройте аутентификацию через Auth0](https://github.com/it-beard/bloggers-cms/wiki/Authorisation-configuration)
3. Запустите проекты Pds.Api (бэкенд-часть CMS) и Pds.Web (фронтенд-часть CMS)
Миграция база и заполнение её начальными данными произайдут автоматически при первом запуске бэкенда (Pds.Api)
#### Настройка фронтенда (проект Pds.Web)
- Настройки фронтенда лежат в файле `bloggers-cms/Pds/Pds.Web/wwwroot/appsettings.Production.json`
   - Секция `Auth0` содержит настройки авторизации сервиса Auth0.
   - Параметр `BackendApi:Url` содержит ссылку на ваш развернутый бэкенд.

#### Настройки бэкенда (проект Pds.Api)
- Настройки бэкенда лежат в файле `bloggers-cms/Pds/Pds.Api/appsettings.json`
   - Секция `Logging` сожержит настройки логирования. Значения по-умолчанию изменений не требуют.
   - Секция `AllowedOrigins` содержит список корневых URL'ов разрешенных фронтенд-приложений. Внесите сюда корневую ссылку на свой развернутый фронтенд.
   - Секция `Auth0` содержит настройки авторизации сервиса Auth0.
   - Параметр `ConnectionStrings:DefaultConnection` содержит строку подключения к базе данных.

# Ссылки
Wiki проекта: https://github.com/it-beard/bloggers-cms/wiki  
Kanban-доска: https://github.com/it-beard/bloggers-cms/projects/1

# Общение
По всем вопросам "[сюда](https://tm.me/iamitbeard)"

# Лицензия

Apache License 2.0, подробнее тут [LICENSE](LICENSE).
