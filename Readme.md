# MotoSocia

## Ayağa Kaldırma
```sh
$ git clone https://github.com/muhammedikinci/MotoSocia.git

$ cd MotoSocia/MotoSocia

$ npm install

~$ npm install --global webpack

$ dotnet run
```

Veritabanı işlemlerinin çalışması için MotoSocia klasörü altında ki appsettings.json dosyası içerisinde bulunan ConnectionStrings in düzenlenmesi gerekiyor.
```json
"ConnectionStrings": {
    "MotoSociaDatabase": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MotoSocia;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
},
```

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

## 4-WebUI
MVC Sistemini içerir. Front-End için npm üzerinden WebPack kullanır.

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
