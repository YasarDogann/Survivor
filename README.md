# Patika+ Survivor App
Merhaba,
Bu proje C# ile Patika+ 12.hafta Survivor uygulaması için yapılmış bir uygulamadır.

## 📚 Proje Hakkında
Bu proje, aşağıdaki konuları öğrenmeye yardımcı olmak için tasarlanmıştır:
- MVC Yapısını kullanmak ve anlamak
- ASP.NET Core Kullanmak
- Entity Framework Kullanmak

 
## İstenilen Görev: 
![m39h_hl-survivor](https://github.com/user-attachments/assets/204bccc3-0519-4472-8e2b-e2cc08cceed5)

Survivor yarışması için bir Web API uygulaması oluşturacaksınız. Bu uygulama, yarışmacılar ve kategoriler arasında bir ilişki içerecek ve bu ilişkilerle ilgili CRUD (Create, Read, Update, Delete) işlemlerini gerçekleştiren API endpointler içerecektir.
Tablolar:

   1. Competitors (Yarışmacılar) Tablosu:

      - Veriler temsilidir.
      ![riOSuXE-YARISMACILAR](https://github.com/user-attachments/assets/09aec9a7-09e0-45b0-b74a-39438398b2b8)

   2. Category (Kategoriler) Tablosu:
    ![aQQ7afs-KATEGORILER](https://github.com/user-attachments/assets/fab3fd8c-6a23-4ff7-af18-99026cc80b6b)


Bir Category birden fazla Competitor'a sahip olabilir. Bu, bire çok (one-to-many) ilişkisidir. Her Competitor yalnızca bir Category'ye ait olacaktır.
Tablolar için gerekli Entityleri oluştururken bir BaseEntity Class'ından yardım alınız.

1. Bir `CompetitorController` ve bir `CategoryController` oluşturun. Bu controller'lar aşağıdaki CRUD işlemlerini yapabilmelidir:
  - CompetitorController:
    - GET `/api/competitors` - Tüm yarışmacıları listele.

    - GET `/api/competitors/{id}` - Belirli bir yarışmacıyı getir.

    - GET `/api/competitors/categories/{CategoryId}` - Kategori Id'ye göre yarışmacıları getir.

    - POST `/api/competitors` - Yeni bir yarışmacı oluştur.

    - PUT `/api/competitors/{id}` - Belirli bir yarışmacıyı güncelle.

    - DELETE `/api/competitors/{id}` - Belirli bir yarışmacıyı sil.
   
 - CategoryController:
    - GET `/api/categories` - Tüm kategorileri listele.

    - GET `/api/categories/{id}` - Belirli bir kategoriyi getir.

    - POST `/api/categories` - Yeni bir kategori oluştur.

    - PUT `/api/categories/{id}` - Belirli bir kategoriyi güncelle.

    - DELETE `/api/categories/{id}` - Belirli bir kategoriyi sil. 
