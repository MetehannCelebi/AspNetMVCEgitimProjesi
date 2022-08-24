var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(); // Uygulamada MVC controller view yap�s�n� kullanaca��z

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // http den https ye otomatik y�nlendire yap
app.UseStaticFiles(); // Uygulamada statik doyalar(wwwroot i�erisindekiler) kullan�labilsin

app.UseRouting(); // Uygulamada Routing mekanizmas�n� aktif et

app.UseAuthentication(); // Uygulamada oturum a�ma i�lemini aktif et
app.UseAuthorization(); // Uygulamada yetkilendirme kullan�m�n� aktif et

app.MapControllerRoute( // uygulamada kullanaca��m�z routing yap�s�
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// E�er birden fazla routing kullanacaksak bu alana ekleyebiliriz
app.Run(); // Uygulamay� �al��t�r
