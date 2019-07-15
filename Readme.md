# MotoSocia
* <b style="color: #239f95">Application</b>
* <b style="color: #239f95">Domain</b>
* <b style="color: #239f95">Infrastructure</b>
* <b style="color: #239f95">WebUI</b>
* <b style="color: #239f95">Persistence</b>

## 1-Application
<hr>
<p>
Bu projede diğer projelerde kullanılacak olan Interface ve Models lar bulunur. EntityFramework için bir <span style="color: tomato">IMotoDBContext</span> Interface i bulunur. Bu Interface <b style="color: #239f95">Persistence</b> içerisinde EF kullanımı için <span style="color: tomato">MotoDBContext</span> olarak <span style="color: tomato">DbContext</span> ile beraber türetilir.
</p> 

<p>
EF kullanımının asıl sağlayıcısı olan <b style="color: #239f95">Domain</b> projesi <b style="color: #239f95">Application</b> dışında hiçbir yapı ile iletişime geçmemesi gerektiği ve <span style="color: tomato">Controller</span> tarafından EF Context ine loose-coupling erişim olması gerektiğinden <b style="color: #239f95">Application</b> içerisinde Command Pattern kullanılmıştır.
</p>

<i>
<b style="color: #239f95">Domain</b> içerisinde bulunan Entities lara erişimin kısıtlanması Models yapılarının <b style="color: #239f95">Application</b> içierisinde oluşturulmasını gerektiriyor.
</i>

## 2-Domain
<hr>
Entities, Value Objects, and Domain Services içerir ve izole bir yapıda olması gerekir.

## 3-Infrastructure
<hr>
Servisleri içerir. (Mail, SMS, Payment)

## 4-WebUI
<hr>
MVC Sistemini içerir. Front-End için npm üzerinden WebPack kullanır.

WebPack İle Yüklenen Paketler;
* ParsleyJS (Front-End Form Validation)
* Babel
* Bootstrap
* jQuery

WebPack scriptleri bu proje altında Scripts klasöründe bulunur. Aynı şekilde WebPack in çalışması için kullanılan npm modullerininde sadece bu proje altına yüklenmesi gerekir. WebPack kodları proje içerisinde ./wwwroot/js/main.build.js dosyasına generate eder.

Proje build aşamasına gelmeden önce WebPack in çalıştırılması için WebUI.csproj içerisinde aşağıda belirtilen kod bloğu bulunuyor.
```xml
<Target Name="MyPreCompileTarget" BeforeTargets="BeforeBuild">
    <Exec Command="webpack" />
</Target>
```

## 4-Persistence
<hr>
<b style="color: #239f95">Application</b> katmanı tarafından etkileşimler için kullanılır ve Migrationlar burada tutulur. 