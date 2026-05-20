# 💎 JewelStore — ювелирный интернет-магазин

<div align="center">

![.NET Version](https://img.shields.io/badge/.NET-8.0-purple)
![Blazor](https://img.shields.io/badge/Blazor-Server-brightgreen)
![Entity Framework](https://img.shields.io/badge/EF%20Core-8.0-blue)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-16-blue)
![Docker](https://img.shields.io/badge/Docker-✓-2496ED)
![License](https://img.shields.io/badge/License-MIT-green)

**Курсовой проект по дисциплине «Кроссплатформенная среда исполнения программного обеспечения»**

</div>

---

## 📖 О проекте

**JewelStore** — это веб-приложение интернет-магазина ювелирных изделий, разработанное на платформе .NET 8 с использованием ASP.NET Core, Blazor Server и PostgreSQL. Приложение позволяет пользователям просматривать каталог украшений (кольца, серьги, подвески, браслеты), управлять корзиной, оформлять заказы с проверкой наличия на складе и просматривать историю покупок.

Проект демонстрирует навыки работы с:
- Кроссплатформенной средой .NET 8
- Entity Framework Core (Code First, Fluent API, миграции)
- Dependency Injection
- Контейнеризацией Docker
- Интерактивными веб-интерфейсами на Blazor Server

---

## ✨ Основные возможности

| Функция | Описание |
|---------|----------|
| 🛍️ **Каталог товаров** | Список ювелирных изделий с ценами, изображениями и описанием |
| 🏷️ **Фильтрация по категориям** | Кольца, Серьги, Подвески, Браслеты |
| 🛒 **Управление корзиной** | Добавление, изменение количества, удаление позиций, расчёт итога |
| 📝 **Оформление заказа** | Форма с валидацией данных покупателя, проверка остатков |
| 📜 **История заказов** | Просмотр всех оформленных заказов с детализацией |
| 👤 **Демо-пользователь** | Гостевой аккаунт (guest@jewelstore.local) без регистрации |
| 🔔 **Модальные окна** | Подтверждение очистки корзины и удаления позиций |
| 🐳 **Полная контейнеризация** | Запуск приложения и БД через Docker Compose |

---

## 🛠️ Технологии

| Технология | Назначение |
|------------|------------|
| .NET 8 | Кроссплатформенная среда исполнения |
| ASP.NET Core | Веб-фреймворк |
| Blazor Server | Интерактивный UI на C# |
| Entity Framework Core 8 | ORM, Code First, миграции |
| PostgreSQL 16 | Реляционная база данных |
| FluentValidation | Валидация моделей |
| Blazored.Modal | Модальные окна |
| Docker / Docker Compose | Контейнеризация |
| Git | Система контроля версий |

---

## 📁 Структура проекта


## 📁 Структура проекта
```
JewelStore/
├── JewelStore/ # 📦 Основной веб-проект
│ ├── Components/ # 🧩 Blazor компоненты
│ │ ├── Layout/ # 🏗️ Макеты и навигация
│ │ │ ├── MainLayout.razor
│ │ │ └── NavMenu.razor
│ │ ├── Pages/ # 📄 Страницы приложения
│ │ │ ├── Home.razor # Главная страница
│ │ │ ├── Products.razor # Каталог товаров
│ │ │ ├── ProductDetails.razor # Карточка товара
│ │ │ ├── Cart.razor # Корзина покупок
│ │ │ ├── Checkout.razor # Оформление заказа
│ │ │ └── Orders.razor # История заказов
│ │ ├── App.razor # Корневой компонент
│ │ ├── Routes.razor # Маршрутизация
│ │ └── _Imports.razor # Общие using-директивы
│ │
│ ├── Data/ # 🗄️ Доступ к данным
│ │ ├── Configurations/ # ⚙️ Fluent API конфигурации
│ │ │ ├── CategoryConfiguration.cs
│ │ │ ├── CustomerConfiguration.cs
│ │ │ ├── OrderConfiguration.cs
│ │ │ ├── ProductConfiguration.cs
│ │ │ └── ProductDetailsConfiguration.cs
│ │ ├── JewelDbContext.cs # 🔗 Контекст БД
│ │ └── JewelSeeder.cs # 🌱 Начальные данные (Seed)
│ │
│ ├── Models/ # 📋 Модели сущностей
│ │ ├── Category.cs # 🏷️ Категория
│ │ ├── Product.cs # 💍 Товар (ювелирное изделие)
│ │ ├── ProductDetails.cs # 📊 Характеристики (проба, вес, производитель)
│ │ ├── Customer.cs # 👤 Покупатель
│ │ ├── Order.cs # 📦 Заказ
│ │ ├── OrderItem.cs # 📃 Позиция заказа
│ │ └── CartItem.cs # 🛒 Корзина
│ │
│ ├── Repositories/ # 📚 Репозитории
│ │ ├── IRepository.cs # 🔌 Интерфейс универсального репозитория
│ │ ├── Repository.cs # ⚙️ Реализация универсального репозитория
│ │ ├── ProductRepository.cs # 📱 Репозиторий товаров (+ Include)
│ │ └── OrderRepository.cs # 📦 Репозиторий заказов (+ Include)
│ │
│ ├── Services/ # ⚙️ Бизнес-логика
│ │ ├── ProductService.cs # CRUD товаров
│ │ ├── CategoryService.cs # CRUD категорий
│ │ ├── CartService.cs # Управление корзиной
│ │ ├── OrderService.cs # Создание заказов, списание товаров
│ │ └── CurrentUserService.cs # 👤 Демо-пользователь (guest)
│ │
│ ├── Validators/ # ✅ FluentValidation валидаторы
│ │ └── Validators.cs # CustomerValidator, CheckoutValidator
│ │
│ ├── wwwroot/ # 🌐 Статические файлы (css, js, images)
│ ├── appsettings.json # ⚙️ Конфигурация
│ ├── appsettings.Development.json # 🛠️ Конфигурация для разработки
│ ├── Program.cs # 🚀 Точка входа, DI, миграции
│ ├── Dockerfile # 🐳 Docker-образ приложения
│ └── JewelStore.dockerignore # 🚫 Исключения для Docker
│
├── docker-compose.yml # 🐳 Оркестрация контейнеров
├── README.md # 📖 Документация
└── .gitignore # 🚫 Исключения для Git
```
---

## 🚀 Быстрый старт

### Предварительные требования

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) (для локальной разработки)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (для контейнеризации)
- [PostgreSQL](https://www.postgresql.org/download/) (при локальном запуске без Docker)
- [Git](https://git-scm.com/)

---

## 🐳 Запуск через Docker (рекомендуемый способ)

Этот способ не требует установки .NET SDK и PostgreSQL на хост-машине — всё работает в изолированных контейнерах.

### Шаг 1: Клонирование репозитория
https://github.com/chich0k/JewelStore
git clone https://github.com/your-username/JewelStore.git
cd JewelStore

### Шаг 2: Запуск контейнеров
docker-compose up -d
### Шаг 3: Открыть приложение
http://localhost:8029
