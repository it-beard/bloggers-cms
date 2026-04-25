[![License](https://img.shields.io/github/license/it-beard/bloggers-cms)](https://github.com/it-beard/bloggers-cms/blob/develop/LICENSE)
[![Stars](https://img.shields.io/github/stars/it-beard/bloggers-cms)](https://github.com/it-beard/bloggers-cms/stargazers)
[![Issues](https://img.shields.io/github/issues/it-beard/bloggers-cms)](https://github.com/it-beard/bloggers-cms/issues)

[![Deploy apps to Production](https://github.com/itbeard/bloggers-cms/actions/workflows/deployment-prod-action.yml/badge.svg?branch=main)](https://github.com/itbeard/bloggers-cms/actions/workflows/deployment-prod-action.yml)

**Bloggers CMS** — это система управления контентом, специально разработанная с учетом потребностей блогеров.
Он работает на базе технологий **.NET 8** и **Blazor WebAssembly**.

Система управления контентом (CMS) позволяет отслеживать:
- Контент и участники контента
- Клиенты
- Доходы и расходы
- Подарки и конкурсы

Дополнительные функции:
- Система аутентификации на базе Auth0 (можно отключить)
- Гибкая система внутренних настроек
- Гибкие фильтры объектов
- Возможность управлять несколькими _брендами_ через единый интерфейс
- «Бренд» — это объект, с которым связаны контент, участники контента, доходы и расходы. Это может быть отдельный канал на YouTube, блогер, проект, компания и т. д.
- Незначительные возможности по предоставлению рекомендаций
<img src="https://github.com/it-beard/bloggers-cms/blob/develop/.github/readme-images/1.png" title="Dashboard" width="800" />

<img src="https://github.com/it-beard/bloggers-cms/blob/develop/.github/readme-images/2.png" title="Content List" width="800" />

<img src="https://github.com/it-beard/bloggers-cms/blob/develop/.github/readme-images/3.png" title="Settings" width="800" />

## Установить и запустить
### Без Docker
1. [Установить и настроить базу данных SQL](https://github.com/it-beard/bloggers-cms/tree/develop/docs/database-setup.md)
2. Отключить аутентификацию Auth0
   - По умолчанию CMS включает [Аутентификация Auth0](https://auth0.com/), что требует дополнительных [настройка](https://github.com/it-beard/bloggers-cms/tree/develop/docs/auth0.md).
   - Чтобы отключить аутентификацию Auth0, установите параметр `Auth0:Enabled` до `false` в следующих файлах:
       -  `bloggers-cms/Pds/Pds.Web/wwwroot/appsettings.Production.json` - отключает аутентификацию на стороне интерфейса
       -  `bloggers-cms/Pds/Pds.Web/wwwroot/appsettings.LocalDevelopment.json` - отключает аутентификацию на локальном экземпляре интерфейса (localhost)
       -  `bloggers-cms/Pds/Pds.Api/appsettings.json` - отключает аутентификацию на стороне сервера
3. Настройте CMS в соответствии с инструкциями, приведенными в "**Settings**" раздел.
4. Запустить `Pds.Api` и `Pds.Web` проекты ([Как запустить приложение .NET](https://github.com/it-beard/bloggers-cms/tree/develop/docs/run.md))
       
_Миграция базы данных произойдет автоматически при первом запуске `Pds.Api` проект._

### С помощью Docker

Чтобы запустить приложение в Docker, просто введите команду:
`docker compose -f "./Pds/.run/docker-compose.yaml" up -d`

#### Особенности приложения в Docker:

1. По умолчанию, [Аутентификация Auth0](https://auth0.com/) является **неработающий**.
2. Данные из базы данных хранятся в отдельном томе, что позволяет сохранять состояние даже после перезапуска или воссоздания контейнеров.
3. Поддержка TLS/SSL отсутствует; поэтому всё работает по протоколу HTTP.
4. Приложение работает в режиме **Разработка**.
5. Фронтенд доступен по адресу [http://localhost:5000](http://localhost:5000).
6. Blazor размещается с помощью [NGINX](https://www.nginx.com/).

## Настройки

### Настройки Pds.Web
Это интерфейс системы управления контентом Bloggers CMS, работающий на Blazor WebAssembly.
Основные настройки находятся в файлах `bloggers-cms/Pds/Pds.Web/wwwroot/appsettings.Production.json` (используемый в производстве) и `bloggers-cms/Pds/Pds.Web/wwwroot/appsettings.LocalDevelopment.json` (используется при локальном запуске):
   - Этот `Auth0` раздел содержит [Auth0](https://auth0.com) параметры аутентификации.
   - Этот `BackendApi:Url` параметр содержит URL-адрес развернутого экземпляра `Pds.Api`.

### Настройки Pds.Api
Это бэкэнд-API системы управления контентом Bloggers, работающей на платформе .NET.

Настройки проекта находятся в файле `bloggers-cms/Pds/Pds.Api/appsettings.json`:
   - Этот `Logging` В этом разделе находятся настройки ведения журнала. Значения по умолчанию, как правило, не требуют изменения.
   - Этот `AllowedOrigins` В этом разделе приведен список корневых URL-адресов разрешенных интерфейсных приложений. Добавьте сюда корневую ссылку на развернутый экземпляр `Pds.Web`.
   - Этот `Auth0` раздел содержит [Auth0](https://auth0.com) параметры аутентификации.
   - Этот `ConnectionStrings:DefaultConnection` Параметр содержит строку подключения к базе данных.

## Полезные ссылки

- [Настройка аутентификации через Auth0](https://github.com/it-beard/bloggers-cms/tree/main/develop/auth0.md)
- [Настройка базы данных](https://github.com/it-beard/bloggers-cms/tree/develop/docs/database-setup.md)
- [Рекомендации по публикации материалов](https://github.com/it-beard/bloggers-cms/tree/develop/docs/code-guidelines.md)
- [Вся документация по проекту](https://github.com/it-beard/bloggers-cms/tree/develop/docs/) 
- По всем вопросам обращайтесь [обсуждения](https://github.com/it-beard/bloggers-cms/discussions)

## Лицензия

Apache License 2.0, см. [ЛИЦЕНЗИЯ](LICENSE) подробнее.
