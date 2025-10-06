# 🛍️ ABC Retail2 — Azure Cloud Application

ABC Retail2 is a C# .NET 8.0 web application integrated with **Microsoft Azure Storage Services**.  
It demonstrates how to use Azure **Tables**, **Blobs**, **Queues**, and **Files** for a retail-based cloud solution.


## 🚀 Project Overview

This project consists of two parts:

### **Part 1 — Web Application**
An ASP.NET Core MVC app that:
- Stores **customer** and **product** data in **Azure Table Storage**.
- Uploads and retrieves **product images** from **Azure Blob Storage**.
- Sends **order processing messages** to **Azure Queues**.
- Uploads **contracts and logs** to **Azure File Storage**.

### **Part 2 — Azure Functions**
A separate Azure Function App (`abc-retail2-functions`) that demonstrates serverless cloud integration by:
1. Writing data to Azure Tables.
2. Uploading files to Blob Storage.
3. Sending/receiving messages in Azure Queues.
4. Writing files to Azure File Shares.


## 🧩 Prerequisites

Before running the project, ensure you have:

- **Visual Studio 2022** or later  
- **.NET 8.0 SDK**  
- **Azure Storage Account** (already created)  
- **Azure Function Tools for Visual Studio**  
- **Azure.Storage.Blobs**, **Azure.Data.Tables**, **Azure.Storage.Queues**, and **Azure.Storage.Files.Shares** NuGet packages


## ⚙️ Setup Instructions

### 1️⃣ Clone the Repository

```bash
git clone https://github.com/<your-username>/ABC-Retail2.git
cd ABC-Retail2
````


### 2️⃣ Configure Azure Connection Strings

In the web project’s `appsettings.json`, update with your Azure connection info:

```json
"AzureStorage": {
  "ConnectionString": "DefaultEndpointsProtocol=https;AccountName=abc1storeage;AccountKey=YOUR_KEY;EndpointSuffix=core.windows.net",
  "BlobContainer": "productimages",
  "CustomerTable": "Customers",
  "ProductTable": "Products",
  "QueueName": "processing-queue",
  "FileShare": "contracts"
}
```

> 💡 Tip: You can find this in the Azure Portal → Storage Account → Access Keys → Connection String.


### 3️⃣ Run the Web Application

In Visual Studio:

1. Set the startup project to **ABC_Retail2**.
2. Press **F5** to run locally.
3. The site will open at `https://localhost:5001` or `http://localhost:5000`.

#### 🧠 Features to Test

* **Customers:** Add, view, and delete customer profiles (Azure Table Storage)
* **Products:** Add product info and upload images (Azure Blob Storage)
* **Queue:** Process orders and log messages (Azure Queue)
* **Files:** Upload and view contract files (Azure File Share)


## ⚡ Part 2: Azure Functions Setup

### 1️⃣ Open the Functions Project

Open your `ABCRetail2Functions` project in Visual Studio.


### 2️⃣ Update `local.settings.json`

Paste your Azure Storage connection string:

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "DefaultEndpointsProtocol=https;AccountName=abc1storeage;AccountKey=YOUR_KEY;EndpointSuffix=core.windows.net",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet"
  }
}
```


### 3️⃣ Run Functions Locally

Press **F5**.
Visual Studio will start the Azure Function host and display endpoints like:

```
Functions:
    StoreCustomerToTable: [POST] http://localhost:7071/api/add-customer
```


### 4️⃣ Test Using Postman

**Example: Add Customer to Azure Table**

1. Open **Postman** → create a **POST** request
2. URL:

   ```
   http://localhost:7071/api/add-customer
   ```
3. Under **Body → raw → JSON**, add:

   ```json
   {
     "FullName": "John Doe",
     "Email": "john@example.com",
     "Phone": "0812345678",
     "Address": "Cape Town"
   }
   ```
4. Click **Send** → Response:

   ```
   ✅ Customer added successfully!
   ```


### 5️⃣ Publish Function to Azure

1. In Visual Studio, right-click the Functions project → **Publish**.
2. Choose **Azure → Azure Function App (Windows)**.
3. Create a new Function App with name:

   ```
   abc-retail2-functions
   ```
4. Deploy it.
5. Your live API URL will be:

   ```
   https://abc-retail2-functions.azurewebsites.net/api/add-customer
   ```


## 🧠 Available Azure Functions

| Function Name        | Description                          | HTTP Method | Example Route       |
| -------------------- | ------------------------------------ | ----------- | ------------------- |
| StoreCustomerToTable | Stores customer info in Azure Tables | POST        | `/api/add-customer` |
| UploadToBlob         | Uploads image/file to Blob Storage   | POST        | `/api/upload-blob`  |
| WriteToQueue         | Sends message to Azure Queue         | POST        | `/api/add-message`  |
| WriteToAzureFile     | Uploads a file to Azure File Share   | POST        | `/api/upload-file`  |


## 🧩 Project Structure

```
ABC-Retail2/
│
├── Controllers/
│   ├── CustomersController.cs
│   ├── ProductsController.cs
│   ├── MediaController.cs
│   ├── QueueController.cs
│   └── FilesController.cs
│
├── Services/
│   ├── TableStorageService.cs
│   ├── BlobStorageService.cs
│   ├── QueueStorageService.cs
│   └── FileShareService.cs
│
├── Views/
│   ├── Customers/
│   ├── Products/
│   ├── Media/
│   ├── Queue/
│   └── Files/
│
└── Program.cs
```


## 🧾 Example Azure Screenshots (for submission)

Include screenshots of:

1. Function App in Azure Portal
2. Function URLs in Azure
3. Data in Azure Table / Blob / Queue / File Share
4. Postman requests and responses


## 🏁 Summary

This project demonstrates:

* ✅ Full integration between ASP.NET Core MVC and Azure Storage
* ✅ Scalable cloud storage (Tables, Blobs, Queues, Files)
* ✅ Serverless operations using Azure Functions
* ✅ Secure, modular, and cost-effective cloud design



**Developed by:** *Anas Al Sarraj*
**Project:** ABC Retail2
**Platform:** Microsoft Azure | .NET 8.0 | ASP.NET Core | C#


