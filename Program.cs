using ABC_Retail2.Services;

var builder = WebApplication.CreateBuilder(args);


string storageConnection = builder.Configuration.GetValue<string>("AzureStorage:ConnectionString");



// Table Storage (Customers & Products)
builder.Services.AddSingleton<TableStorageService>(sp =>
    new TableStorageService(storageConnection)
);

// Blob Storage (Product Images / Media)
builder.Services.AddSingleton<BlobStorageService>(sp =>
    new BlobStorageService(storageConnection, "productimages")
);

// Queue Storage (Processing Orders)
builder.Services.AddSingleton<QueueStorageService>(sp =>
    new QueueStorageService(storageConnection, "processing-queue")
);

// File Share Storage (Contracts / Logs)
builder.Services.AddSingleton<FileShareService>(sp =>
    new FileShareService(storageConnection, "contracts")
);


builder.Services.AddControllersWithViews();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
