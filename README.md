ToDo Uygulaması
Bu proje, ASP.NET Core Web API (MediatR) ve Angular 20 kullanılarak geliştirilmiş, SQL Server veritabanı üzerinde çalışan tam işlevli bir yapılacaklar listesi (ToDo) uygulamasıdır. Kullanıcılar görev ekleyebilir, listeleyebilir, güncelleyebilir ve silebilir. Backend tarafında C# ile API geliştirilmiş, frontend tarafında ise Angular kullanılmıştır.

Kullanılan Teknolojiler
Backend için ASP.NET Core 8, MediatR, Entity Framework Core ve SQL Server kullanılmıştır. Ayrıca AutoMapper ile nesne dönüşümleri yapılmaktadır. Frontend için Angular 20, TypeScript ve SCSS tercih edilmiştir. API ile frontend arasında HTTP istekleri HttpClientModule aracılığıyla gerçekleştirilir.

Projenin Çalıştırılması
Öncelikle backend için SQL Server üzerinde veritabanı oluşturulmalı ve Entity Framework Core ile migrasyonlar uygulanmalıdır. appsettings.json dosyasındaki "DefaultConnection" ayarı kendi bilgisayarınızda çalışan SQL Server'a göre düzenlenmelidir. Visual Studio’da Package Manager Console açılarak sırasıyla Add-Migration Initial Migration ve Update-Database komutları çalıştırılarak veritabanı yapılandırılır.

Backend projesi Visual Studio 2022’de açılır ve API projesi startup olarak seçilip Ctrl + F5 ile çalıştırılır.

Frontend için terminalden frontend klasörüne gidilir. Burada npm install ile bağımlılıklar yüklenir. Ardından ng serve komutu ile Angular uygulaması başlatılır. 



API Endpointleri

- Tüm Görevleri Getir**  
  GET /api/ToDo`  
  Açıklama: Sistemdeki tüm yapılacaklar listesini getirir.

- ID’ye Göre Görev Getir**  
  GET /api/ToDo/{id}`  
  Açıklama: Belirtilen ID’ye sahip görevi getirir.  
  Örnek: `/api/ToDo/3fa85f64-5717-4562-b3fc-2c963f66afa6`

- Yeni Görev Ekle**  
  POST /api/ToDo`  
  Açıklama: Yeni bir görev oluşturur.  
  Örnek İstek Gövdesi (JSON):
  json
  {
    "title": "Alışveriş Yap",
    "description": "Marketten süt ve ekmek alınacak.",
    "isCompleted": false
  }

PUT /api/ToDo/{id}
Açıklama: Mevcut görevi günceller.
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "title": "Alışveriş Yap",
  "description": "Marketten süt ve ekmek alınacak.",
  "isCompleted": true
}

DELETE /api/ToDo/{id}
Açıklama: Belirtilen ID’ye sahip görevi siler.
Örnek: /api/ToDo/3fa85f64-5717-4562-b3fc-2c963f66afa6


Setup Adımları 

 Kurulum Adımları

 Veritabanı bağlantısını ayarla 
   `backend/appsettings.json` içinde `"DefaultConnection"` ayarını kendi SQL Server bilgilerine göre güncelle:

   json
   "ConnectionStrings": {
     "DefaultConnection": "Server=.;Database=ToDo;Trusted_Connection=True;"
   }

EF Core ile veritabanını oluştur
Visual Studio'da Package Manager Console aç:

Add-Migration Initial Migration
Update-Database

Backend API’yi çalıştır


Frontend’i başlat
Terminali aç, frontend klasörüne gir:

cd frontend
npm install
ng serve


API URL’sini ayarla


