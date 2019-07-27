<p align="center">
<img src="https://github.com/muhammedikinci/MotoSocia/blob/master/MotoSocia/wwwroot/img/MotoSocia%20Logo%20Test%201.png" width="500px" height="200px" />
</p>

<br/>

<p align="center"><a href="https://trello.com/b/NFdach5G/myaccount-component">Trello Board</a></p>

## Ayağa Kaldırma
```sh
// Repo yu klonla
$ git clone https://github.com/muhammedikinci/MotoSocia.git

// MVC projesine git
$ cd MotoSocia/MotoSocia

// NPM bağımlılıklarını yükle
$ npm install

// Yoksa Webpack i global olarak yükle
~$ npm install --global webpack

// Ana klasöre dön
~$ cd ../

// İhtiyaç varsa entity framework ile migration oluştur ve veritabanına uygula
~$ dotnet ef migrations add changemodel --context Persistence.MotoDBContext --output-dir Migrations --project Persistence -s MotoSocia
~$ dotnet ef database update changemodel --context Persistence.MotoDBContext --project Persistence -s MotoSocia

// MVC projesine dön
~$ cd MotoSocia

// Çalıştır
$ dotnet run
```

Veritabanı Connection String leri appsettings.json içerisinde ki ConnectionStrings altında bulunur.
```json
"ConnectionStrings": {
    "MotoSociaDatabase": "Connection String"
},
```

## Teknolojiler
* ASP.NET Core App (2.2.6)
* Entity FrameWork Core (2.2.6)
* xUnit (2.4.1)
* SendGrid (9.11.0)
* PaulMiami Recaptcha (1.2.1)(Google Recaptcha v2)
* NPM (6.9.2)

## Proje Yapısı

* <b style="color: #239f95">Application</b>
* <b style="color: #239f95">Domain</b>
* <b style="color: #239f95">Infrastructure</b>
* <b style="color: #239f95">WebUI</b>
* <b style="color: #239f95">Persistence</b>

## 1-Application
<p>
Bu projede diğer projelerde kullanılacak olan Interface ve Models lar bulunur. <br>
<span style="color: tomato">IMotoDBContext</span> Interface i barındırır.<br>Bu Interface <b style="color: #239f95">Persistence</b> projesi içerisinde <span style="color: tomato">MotoDBContext</span> olarak <span style="color: tomato">DbContext</span> ile beraber türetilir.
</p> 
<p>
<b style="color: #239f95">Domain</b> içerisinde bulunan Entities lara erişimin kısıtlanması Models yapılarının <b style="color: #239f95">Application</b> içierisinde oluşturulmasını gerektiriyor.
</p>

## 2-Domain
Entities, Value Objects, Domain Services içerir ve izole bir yapıda olması gerekir.

## 3-Infrastructure
Servisleri içerir. (Mail, SMS, Payment)

<img src="https://sendgrid.com/brand/sg-twilio/sg-twilio-lockup.svg" width="200" height="50" />

Mail için SendGrid kullanılıyor. APIKey girmek için appsettings.json -> SendGridEmailService -> APIKey objesine inmek gerekiyor.
```json
  "SendGridEmailService": {
    "APIKey":  "SENDGRIDAPIKEY"
  },
```

## 4-WebUI
MVC Sistemini içerir. 

Form validasyonları için ParsLeyJS in yanında Recaptcha ve güvenliği arttırmak için AntiForgeryToken kullanılıyor.

<img src="https://webpack.js.org/e0b5805d423a4ec9473ee315250968b2.svg" width="200" height="50" />
Front-End için npm üzerinden WebPack kullanır.

WebPack İle Yüklenen Paketler;
* ParsleyJS (Front-End Form Validation)
* Babel
* Bootstrap
* jQuery

WebPack scriptleri bu proje altında Scripts klasöründe bulunur. Aynı şekilde WebPack in çalışması için kullanılan npm modullerinin de sadece bu proje altına yüklenmesi gerekir. WebPack kodları proje içerisinde ./wwwroot/js/main.build.js dosyasına generate eder.

Proje build aşamasına gelmeden önce WebPack in çalıştırılması için WebUI.csproj içerisinde aşağıda belirtilen kod bloğu bulunuyor.
```xml
<Target Name="MyPreCompileTarget" BeforeTargets="BeforeBuild">
    <Exec Command="npm run build" />
</Target>
```

## 4-Persistence
<b style="color: #239f95">Application</b> katmanı tarafından etkileşimler için kullanılır ve Migrationlar burada tutulur. 
