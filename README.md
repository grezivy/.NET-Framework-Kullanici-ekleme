<img width="861" height="712" alt="image" src="https://github.com/user-attachments/assets/385d0ac1-5e46-43c3-bcea-ad8e957a3fd5" />


WindowsFormsApp10 - Öğrenci Yönetim Sistemi

Bu proje, C# Windows Forms ve Entity Framework kullanılarak geliştirilmiş basit bir öğrenci kayıt ve yönetim uygulamasıdır.

Uygulama üzerinden öğrenciler listelenebilir, yeni öğrenci eklenebilir, mevcut öğrenciler güncellenebilir, silinebilir ve öğrenci bilgileri üzerinden arama yapılabilir.

Kullanılan Teknolojiler

C#

.NET Framework

Windows Forms

Entity Framework

LINQ

SQL Server

Visual Studio

Proje Yapısı

Temel olarak uygulamada aşağıdaki yapı kullanılmaktadır:

Form1.cs → Kullanıcı arayüzü ve CRUD işlemleri

Tarsus2026Entities → Entity Framework veritabanı bağlantısı

Students2026 → Öğrenci entity/model sınıfı

DataGridView → Öğrencilerin listelenmesi

TextBox kontrolleri → Öğrenci bilgilerinin girilmesi

Öğrenci Bilgileri

Uygulamada öğrenciler için aşağıdaki bilgiler kullanılmaktadır:

Alan	Açıklama
id	Öğrencinin benzersiz ID değeri
name	Öğrencinin adı
surname	Öğrencinin soyadı
email	Öğrencinin e-posta adresi
Uygulama Özellikleri
1. Öğrencileri Listeleme

Uygulama açıldığında Form1_Load içerisinde listele() metodu çalıştırılır.

void listele()
{
    Tarsus2026Entities tau = new Tarsus2026Entities();
    dataGridView1.DataSource = tau.Students2026.ToList();
}


Bu metot veritabanındaki tüm öğrencileri DataGridView içerisinde gösterir.

2. Öğrenci Ekleme

Ekle butonuna basıldığında TextBox alanlarındaki bilgiler alınarak yeni bir Students2026 nesnesi oluşturulur.

Students2026 std = new Students2026
{
    name = txtAd.Text,
    surname = txtSoyad.Text,
    email = txtEmail.Text
};


Daha sonra öğrenci veritabanına eklenir ve SaveChanges() ile kaydedilir.

3. Öğrenci Seçme

DataGridView içerisindeki bir öğrenciye tıklandığında öğrencinin ID bilgisi secilenid değişkeninde tutulur.

Aynı zamanda öğrencinin adı, soyadı ve e-posta adresi ilgili TextBox alanlarına aktarılır.

secilenid = Convert.ToInt32(
    dataGridView1.CurrentRow.Cells[0].Value.ToString()
);


Bu ID, güncelleme ve silme işlemlerinde kullanılır.

4. Öğrenci Silme

Seçilen öğrencinin ID'si kullanılarak öğrenci veritabanından bulunur ve silinir.

tau.Students2026.Remove(
    tau.Students2026.Find(secilenid)
);

tau.SaveChanges();


Silme işleminden sonra liste tekrar yüklenir.

5. Öğrenci Güncelleme

Seçilen öğrencinin ID'si ile veritabanındaki kayıt bulunur.

Ad, soyad ve e-posta bilgileri TextBox'lardan alınarak güncellenir.

var guncelle = tau.Students2026.Find(secilenid);

guncelle.name = txtAd.Text;
guncelle.surname = txtSoyad.Text;
guncelle.email = txtEmail.Text;

tau.SaveChanges();

6. Öğrenci Arama

Arama işlemi LINQ kullanılarak gerçekleştirilmektedir.

Örneğin öğrencinin adına göre arama:

tau.Students2026
    .Where(x => x.name.Contains(txtAd.Text))
    .ToList();

Veritabanı

Proje, Entity Framework üzerinden Tarsus2026Entities sınıfını kullanarak veritabanına bağlanmaktadır.

Ana tablo:

Students2026


Örnek tablo yapısı:

Students2026
├── id
├── name
├── surname
└── email


Veritabanı bağlantı bilgilerinin çalıştırılan bilgisayardaki SQL Server yapılandırmasına göre ayarlanması gerekir.

Kurulum

Projeyi Visual Studio ile açın.

SQL Server üzerinde gerekli Tarsus2026 veritabanını oluşturun.

Students2026 tablosunun mevcut olduğundan emin olun.

Entity Framework bağlantısını kontrol edin.

Gerekli NuGet paketlerinin yüklü olduğundan emin olun.

Projeyi Build edin.

Uygulamayı çalıştırın.

Kullanım

Uygulama açıldığında öğrenciler DataGridView içerisinde listelenir.

Yeni öğrenci eklemek için:

Ad alanını doldurun.

Soyad alanını doldurun.

E-posta alanını doldurun.

Ekle butonuna basın.

Öğrenci güncellemek veya silmek için:

DataGridView üzerinden öğrenciyi seçin.

Bilgileri düzenleyin veya doğrudan silme işlemini gerçekleştirin.

Güncelleme için Güncelle, silme için Sil butonunu kullanın.

Önemli Not

Mevcut btnSearch_Click kodunda üç farklı arama sorgusu arka arkaya çalıştırıldığı için her sorgu bir önceki DataSource değerinin üzerine yazmaktadır. Ayrıca en sonunda listele() çağrıldığı için arama sonucu tekrar tüm öğrenciler gösterilmektedir.

Arama işleminin doğru çalışması için ad, soyad ve e-posta kriterlerinin tek bir LINQ sorgusunda birleştirilmesi önerilir.

Örneğin:

private void btnSearch_Click(object sender, EventArgs e)
{
    Tarsus2026Entities tau = new Tarsus2026Entities();

    var sonuc = tau.Students2026
        .Where(x =>
            x.name.Contains(txtAd.Text) &&
            x.surname.Contains(txtSoyad.Text) &&
            x.email.Contains(txtEmail.Text))
        .ToList();

    dataGridView1.DataSource = sonuc;
}


Bu şekilde girilen kriterlere uyan öğrenciler listelenir.

Geliştirme Önerileri

Projeye ilerleyen aşamalarda aşağıdaki özellikler eklenebilir:

Boş alan kontrolü

E-posta formatı kontrolü

Silme işleminde kullanıcıdan onay alma

Arama kriterlerini temizleme butonu

ID yerine öğrenci numarası kullanma

Daha gelişmiş filtreleme

Hata yönetimi (try-catch)

Veritabanı bağlantı hatalarının kontrol edilmesi

Kullanıcı dostu hata ve başarı mesajları

Entity Framework DbContext nesnesinin daha düzenli yönetilmesi

Lisans

Bu proje eğitim amaçlı geliştirilmiştir.
