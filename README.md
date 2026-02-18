# BarnManagement

.NET 9.0 kullanılarak geliştirilmiş, çiftlik yönetim WinForm uygulaması.

## Özellikler:
- **Rol Yönetimi:**
	- Admin, User adında iki adet kullanıcı bulunur.
	- Kullanıcı giriş sistemi ile kullanıcı giriş yapar
	- Admin, yeni kullanıcı oluşturma ve listeleme yetkisine sahiptir.
- **Çiftlik Yönetimi:**
	- Her kullanıcının bir adet çiftliği bulunur
	- Kullanıcıya tanımlı çiftliğe hayvan alımı yapılabilir.
- **Hayvan Yönetimi:**
	- Çiftliğe alınan her hayvan 3 ay yaşında alınır.
	- Çiftlikte bulunan hayvanların yaşı 6 ayı geçtikten sonra üretime başlarlar.
	- Her hayvan, türüne bağlı olarak yaşam süresini doldurduktan sonra ölür.
- **Üretim Yönetimi:**
	- Her hayvan, türüne bağlı olarak bir adet ürün üretir.
	- Çiftlikte bulunan hayvan sayısına göre üretim miktarı artar.
	- Üretime uygun olan hayvanlar üretim listesine alınır.
	- Üretime uygun olmayan hayvanlar üretim listesinden çıkarılır.
- **Envanter Yönetimi:**
	- Hayvanlar üretim yaptıktan sonra cart'ta biriken ürünler envantere alınır.
	- Envanterde bulunan her ürün istenilen adette satılabilir.
- **Hata Yönetimi ve Loglama:**
	- Alınan hatalar Logs dosyasına kaydedilir.

## Mimari:

- **Business:** İş mantığının, kuralların ve veri işleme süreçlerinin yönetildiği ana katman.
    - **Abstract:** Servis arayüzlerinin tanımlandığı alan.
    - **Constants:** Proje genelinde kullanılan sabit mesaj ve değerlerin bulunduğu klasör.
    - **DTOs:** Katmanlar arası veri transferinde kullanılan nesnelerin bulunduğu alan.
    - **Profiles:** Automapper eklentisinin kontrol edildiği profil.
    - **Services:** İş mantığının kodlandığı ve hesaplamaların yapıldığı sınıflar.
- **Core:** Projenin genel altyapı ve yardımcı bileşenlerinin bulunduğu katman.
    - **Logging:** Uygulama içi hataların ve olayların kayıt altına alındığı loglama mekanizması.
- **Data:** Veritabanı bağlantısı ve veri erişim işlemlerinin yapılandırıldığı katman.
- **Model:** Veritabanı tablolarını temsil eden ana varlıkların tanımlandığı katman.
- **View:** Kullanıcının etkileşime girdiği arayüz katmanı.
    - **Pages:** Uygulama içerisindeki panellerin ve kullanıcı kontrollerinin bulunduğu alan.
    - **Forms:** Login ve MainForm gibi ana pencerelerin yönetildiği sınıflar.
        

## Kullanılan Teknolojiler:
- .NET 9.0
- C# Windows Form
- **NuGet paketleri:**
	- AutoMapper
	- AspNetCore.Identity
	- EntityFrameworkCore.SqlServer
	- EntityFrameworkCore.Tools

## Kurulum:
- Repoyu klonlayın
	 `git clone https://github.com/Omercanonen/BarnManagement`
- Projeyi Visual Studio 2022 ile açın
- Gerekli NuGet paketlerini indirin
- Projeyi başlatın

## Klasör Yapısı:
```
BarnManagement
├── Business                
│   ├── Abstract          
│   ├── Constants           
│   ├── DTOs               
│   ├── Profiles          
│   └── Services           
├── Core                   
│   └── Logging           
├── Data                   
│   └── AppDbContext.cs    
├── Migrations            
├── Model                
├── View                 
│   ├── Pages              
│   ├── Login.cs           
│   └── MainForm.cs         
├── appsettings.json        
└── Program.cs             
```
