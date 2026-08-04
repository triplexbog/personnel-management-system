<div align="center">

# Personnel

### Настольная информационная система для управления персоналом

![C#](https://img.shields.io/badge/C%23-WinForms-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![.NET Framework](https://img.shields.io/badge/.NET_Framework-4.7.2-5C2D91?style=for-the-badge&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-2019%2B-CC2927?style=for-the-badge&logo=microsoftsqlserver&logoColor=white)

</div>

## О проекте

**Personnel** — учебное Windows-приложение для ведения профилей сотрудников и обучающихся, хранения документов и достижений, управления пользователями и формирования отчётов.

Проект подготовлен для безопасной публикации: исходный дамп базы, локальные сборки, пользовательские файлы, логины, хеши паролей и персональные записи в репозиторий не входят.

## Возможности

- авторизация пользователей и управление ролями;
- создание и редактирование профилей;
- учёт достижений и прикреплённых материалов;
- иерархическое хранение документов и их версий;
- ведение истории статусов;
- управление пользователями;
- формирование отчётов с экспортом в Excel и CSV.

## Технологии

| Компонент | Технология |
|---|---|
| Интерфейс | Windows Forms |
| Платформа | .NET Framework 4.7.2 |
| Язык | C# |
| База данных | Microsoft SQL Server 2019+ |
| Доступ к данным | ADO.NET (`System.Data.SqlClient`) |
| Экспорт в Excel | EPPlus 5.8.0 |

## Быстрый запуск

### 1. Требования

- Windows 10/11;
- Visual Studio 2019 или 2022 с компонентом **Разработка классических приложений .NET**;
- .NET Framework 4.7.2 Developer Pack;
- Microsoft SQL Server 2019 или новее;
- SQL Server Management Studio — рекомендуется для выполнения скрипта.

### 2. Создание базы данных

Откройте [`database/PersonnelDB.sql`](database/PersonnelDB.sql) в SQL Server Management Studio и выполните скрипт целиком. Он:

- создаст базу `PersonnelDB`;
- создаст таблицы, ограничения и связи;
- добавит только безопасные справочные данные;
- не добавит профили, документы, логины или другие персональные записи.

Скрипт намеренно завершится ошибкой, если база `PersonnelDB` уже существует, чтобы не перезаписать данные.

### 3. Создание первого администратора

После создания базы выполните отдельный запрос, заменив значения переменных своими. Не сохраняйте настоящий пароль в репозитории.

```sql
USE [PersonnelDB];

DECLARE @AdminLogin NVARCHAR(100) = N'admin';
DECLARE @AdminPassword NVARCHAR(4000) = N'укажите_надёжный_пароль';

IF @AdminPassword = N'укажите_надёжный_пароль' OR LEN(@AdminPassword) < 12
    THROW 50002, N'Укажите собственный пароль длиной не менее 12 символов.', 1;

INSERT INTO dbo.Users (Login, PasswordHash, RoleId)
VALUES
(
    @AdminLogin,
    HASHBYTES(
        'SHA2_256',
        CONVERT(VARCHAR(8000), @AdminPassword COLLATE Latin1_General_100_BIN2_UTF8)
    ),
    1
);
```

### 4. Настройка подключения

По умолчанию приложение подключается к локальному экземпляру SQL Server через Windows-аутентификацию. При необходимости измените `PersonnelDb` в [`Personnel/App.config`](Personnel/App.config):

```xml
<add name="PersonnelDb"
     connectionString="Data Source=.;Initial Catalog=PersonnelDB;Integrated Security=True;Encrypt=False"
     providerName="System.Data.SqlClient" />
```

Примеры `Data Source`:

- `.` — локальный экземпляр по умолчанию;
- `.\SQLEXPRESS` — локальный SQL Server Express;
- `(localdb)\MSSQLLocalDB` — SQL Server LocalDB.

Не добавляйте логин или пароль от SQL Server в отслеживаемый `App.config`. Для локальных секретов используйте неотслеживаемую конфигурацию или Windows-аутентификацию.

### 5. Сборка и запуск

1. Откройте `Personnel.sln` в Visual Studio.
2. Восстановите NuGet-пакеты для решения.
3. Соберите решение в конфигурации `Debug` или `Release`.
4. Запустите проект `Personnel` и войдите под созданной учётной записью.

## Структура проекта

```text
Personnel/
├── database/
│   └── PersonnelDB.sql       # схема и безопасные справочники
├── Personnel/
│   ├── bd/                   # подключение к базе данных
│   ├── forms/                # формы приложения
│   ├── Properties/           # ресурсы и настройки проекта
│   ├── App.config            # строка подключения
│   └── Personnel.csproj
├── Personnel.sln
├── .gitignore
└── README.md
```

## Безопасность данных

- Исходные пароли в коде и SQL отсутствуют. Учебная версия использует SHA-256; для промышленной эксплуатации его следует заменить на Argon2, bcrypt или PBKDF2 с уникальной солью.
- Запросы приложения используют параметры вместо конкатенации пользовательского ввода.
- Файлы `*.bacpac`, `*.bak`, локальные PDF, каталоги сборки и восстановленные NuGet-пакеты исключены через `.gitignore`.
- Перед публикацией новых данных проверяйте репозиторий на персональные сведения, строки подключения и секреты.
