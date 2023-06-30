[![License](https://img.shields.io/github/license/it-beard/bloggers-cms)](https://github.com/it-beard/bloggers-cms/blob/develop/LICENSE)
[![Stars](https://img.shields.io/github/stars/it-beard/bloggers-cms)](https://github.com/it-beard/bloggers-cms/stargazers)
[![Issues](https://img.shields.io/github/issues/it-beard/bloggers-cms)](https://github.com/it-beard/bloggers-cms/issues)

[![Deploy apps to Production](https://github.com/itbeard/bloggers-cms/actions/workflows/deployment-prod-action.yml/badge.svg?branch=main)](https://github.com/itbeard/bloggers-cms/actions/workflows/deployment-prod-action.yml)

**Bloggers CMS** - это система управления контентом, разрабатываемая специально под задачи блогеров. Платформа создается как часть экосистемы вокруг проекта ["АйТиБорода"](https://itbeard.com).   
Работает на базе технологий **.NET 7** и **Blazor WebAssembly**

CMS позволяет вести учёт:
- Контента
- Участников контента
- Клиентов
- Доходов и расходов
- Подарков и конкурсов

Дополнительные фичи: 
- Система аутентификации на базе Auth0 (может быть отключена)
- Гибкая система внутренних настроек
- Гибкие фильтры по сущностям
- Возможность вести учёт нескольких _Брендов_ в рамках одног оинтерфейса
   - "Бренд" - это сущность, к которой привязывается контент, участники контента, доходы и расходы. Это может быть отдельный YT-канал, блогер, проект, компания и т.д.
- Небольшие рекомендательные возможности

<img src="https://github.com/it-beard/bloggers-cms/blob/develop/.github/readme-images/1.png" title="Дашборд" width="800" />

<img src="https://github.com/it-beard/bloggers-cms/blob/develop/.github/readme-images/2.png" title="Список контента" width="800" />

<img src="https://github.com/it-beard/bloggers-cms/blob/develop/.github/readme-images/3.png" title="Настройки" width="800" />

# Запуск
1. [Установите и настройте SQL базу данных](https://github.com/it-beard/bloggers-cms/wiki/how-to-create-db)
2. Отключите Auth0-аутентификацию
   - По умолчанию в CMS включена [Auth0-аутентификация](https://auth0.com/), требующая дополнительных [танцев с бубном](https://github.com/it-beard/bloggers-cms/wiki/Authorisation-configuration).
   - Для отключения Auth0-аутентификации выставьте параметр `Auth0:Enabled` в значение `false` в следующих файлах:
       -  `bloggers-cms/Pds/Pds.Web/wwwroot/appsettings.Production.json` - отключает аутентификацию на стороне фронтенда
       -  `bloggers-cms/Pds/Pds.Web/wwwroot/appsettings.LocalDevelopment.json` - отключает аутентификацию на стороне локального инстанса фронтенда (localhost)
       -  `bloggers-cms/Pds/Pds.Api/appsettings.json` - отключает аутентификацию на стороне бекенда
3. Настройте CMS в соответствии с описанием в разделе "**Основные настройки**".
4. Запустите проекты `Pds.Api` и `Pds.Web`
   
_Миграция базы данных произайдёт автоматически при первом запуске проекта `Pds.Api`_

# Основные настройки
### Проект Pds.Web 
Это фронтенд Blogger CMS, работает на Blazor WebAssembly

Основные настройки расположны в файлах `bloggers-cms/Pds/Pds.Web/wwwroot/appsettings.Production.json` (используются на продакшене) и `bloggers-cms/Pds/Pds.Web/wwwroot/appsettings.LocalDevelopment.json` (используются при запуске локально)
   - Секция `Auth0` содержит настройки аутентификации [Auth0](https://auth0.com).
   - Параметр `BackendApi:Url` содержит URL развернутого инстанса `Pds.Api`.

### Проект Pds.Api 
Это бекенд-api Blogger CMS, работает на .NET

Настройки проекта находятся в файле `bloggers-cms/Pds/Pds.Api/appsettings.json`
   - Секция `Logging` сожержит настройки логирования. Значения по-умолчанию изменений не требуют.
   - Секция `AllowedOrigins` содержит список корневых URL'ов разрешенных фронтенд-приложений. Внесите сюда корневую ссылку на развернутый инстанс `Pds.Web`.
   - Секция `Auth0` содержит настройки аутентификации [Auth0](https://auth0.com).
   - Параметр `ConnectionStrings:DefaultConnection` содержит строку подключения к базе данных.

# Полезные ссылки
Настройка аутентификации в CMS через Auth0: https://github.com/it-beard/bloggers-cms/wiki/Authorisation-configuration
Wiki проекта: https://github.com/it-beard/bloggers-cms/wiki  
Kanban-доска: https://github.com/orgs/it-beard/projects/4

# Общение
По всем вопросам [сюда](https://tm.me/iamitbeard)

# Лицензия

Apache License 2.0, подробнее тут [LICENSE](LICENSE).
