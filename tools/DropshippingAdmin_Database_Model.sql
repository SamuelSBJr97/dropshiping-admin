-- Serviço de Autenticação
CREATE TABLE Users (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    TwoFactorEnabled BIT DEFAULT 0,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Serviço de Pagamentos
CREATE TABLE PaymentsStatus (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    [Status] NVARCHAR(50) CHECK (Status IN ('pending', 'paid', 'canceled', 'failed', 'deleted')) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Payments (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    UserId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Users(Id) NOT NULL,
    Amount DECIMAL(10,2) NOT NULL,
    [Status] UNIQUEIDENTIFIER FOREIGN KEY REFERENCES PaymentsStatus(Id),
    CreatedAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE Transactions (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    TransactionId NVARCHAR(255) NOT NULL,
    PaymentId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Payments(Id) NOT NULL,
    Gateway NVARCHAR(100) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE()
);

-- Serviço de WhatsApp
CREATE TABLE WhatsAppMessagesStatus (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    [Status] NVARCHAR(50) CHECK ([Status] IN ('sent', 'delivered', 'failed', 'deleted')) NOT NULL,
    SentAt DATETIME DEFAULT GETDATE()
);

CREATE TABLE WhatsAppMessages (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    UserId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	MessageContent NVARCHAR(MAX) NOT NULL,
    SentAt DATETIME DEFAULT GETDATE(),
    [Status] UNIQUEIDENTIFIER FOREIGN KEY REFERENCES WhatsAppMessagesStatus(Id),
);

-- Serviço de Notificações
CREATE TABLE Notifications (
    Id UNIQUEIDENTIFIER PRIMARY KEY,
    UserId UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Users(Id) NOT NULL,
    [Type] NVARCHAR(50) CHECK (Type IN ('email', 'whatsApp')) NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    SentAt DATETIME DEFAULT GETDATE()
);