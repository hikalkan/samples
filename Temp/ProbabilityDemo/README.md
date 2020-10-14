## Soru 1

Bir yarışma programındasın, 2 tane kapalı kapı var önünde. Her bir kapının arkasında 1 çocuk var. Çocukların cinsiyeti tamamen **rastgele** seçilmiş durumda, programın sunucusunun dahi haberi yok.

Sonra sunucu geliyor stüdyoya, sana göstermeden kapıların arkasına bakıyor ve sana dönüp diyor ki: "**Çocuklardan en az birisi kız. Sence ikisi birden mi kız yoksa birinde kız birinde erkek mi var?**"

Buradaki mantıklı cevap "birisi erkek birisi kız" olacaktır. Bu durumda kazanma şansın **2/3**. Eğer "ikisi de kız" dersen kazanma şansın **1/3**.

### İspat

Bunu zaten [Yaşar Safkan Hoca videosunda](https://youtu.be/fEjusut_tVI?t=390) ispatlamıştı, problem yok. Ama bilmeyenler için ispatlayalım;

Çocuklar rastgele cinsiyetlerle yerleştirildiğine göre 4 farklı durum olabilir;

* A) Kapı-1: **Kız**, Kapı-2: **Kız**
* B) Kapı-1: **Kız**, Kapı-2: **Erkek**
* C) Kapı-1: **Erkek**, Kapı-2: **Kız**
* D) Kapı-1: **Erkek**, Kapı-2: **Erkek**

Bu dört durumun da olasılığı 1/4 (%25). Sunucu bize "en az birisi kız" bilgisini verdiğine göre "D) Kapı-1: Erkek, Kapı-2: Erkek" durumu eleniyor.

Geriye kalan 3 ihtimalin kendi aralarında olasılığı eşit ve her birinin 1/3. Bu 3 durumdan sadece (A) durumunda "iki kız" olduğu için ve A'nın olasılığı 1/3 olduğu için "iki kız" durumunun olma olasılığı 1/3 diyebiliriz. B ve C durumlarında "bir erkek bir kız" olduğu için de bu cevabı vermek kazanma olasılığımızı artırır.

## Soru 2

Her şey soru 1'deki gibi gerçekeşti ve sunucu yine "**Çocuklardan en az birisi kız. Sence ikisi birden mi kız yoksa birinde kız birinde erkek mi var?**" dedi. Sen henüz cevap vermeden senin zorlandığını düşündüğü için acımış olsa gerek, "Dur sana bir güzellik yapıyım" diyerek **arkasında kız olduğunu bildiği** bir kapıyı açtı ve sana kız çocuğunu gösterdi, hatta adını da sordu çocuğa, o da "**Ayşe**" dedi.

Şimdi senden bir cevap bekleniyor. "İkisi de kız" mı dersin yoksa "bir kız bir erkek" hala daha mantıklı mı?

**Benim görüşüm**: Değişen bir şey yoktur. Yani hala "iki kız" olasılığı 1/3, "bir kız bir erkek" olasılığı 2/3'tür.

### İspat

Çocuklar rastgele cinsiyetlerle yerleştirildiğine göre 4 farklı durum olabilir;

* A) Kapı-1: **Kız**, Kapı-2: **Kız**
* B) Kapı-1: **Kız**, Kapı-2: **Erkek**
* C) Kapı-1: **Erkek**, Kapı-2: **Kız**
* D) Kapı-1: **Erkek**, Kapı-2: **Erkek**

Bu dört durumun da olasılığı 1/4 (%25). Sunucu bize "en az birisi kız" bilgisini verdiğine göre "D) Kapı-1: Erkek, Kapı-2: Erkek" durumu eleniyor, ve ihtimaller şöyle güncelleniyor:

* A) Kapı-1: **Kız**, Kapı-2: **Kız** (1/3)
* B) Kapı-1: **Kız**, Kapı-2: **Erkek** (1/3)
* C) Kapı-1: **Erkek**, Kapı-2: **Kız** (1/3)

Her 3 durumda da sunucu (kız olduğunu kesin bildiği) bir kapının arkasından bir çocuk çıkarabilir ve adını söyletebiir;

* A durumunda sunucu kapılardan kafasına göre birisini seçebilir. Kızlardan birinin adı Ayşe diğeri Fatma olabilir. Ayşe'yi seçerse çocuk adını sorulduğunda "Ayşe", diğer kızı seçerse "Fatma" diyecek. Sonuçta **çocuğun ismini sunucu seçtikten sonra öğreniyoruz**.
* B durumunda sunucu Kapı-1'i seçecektir, çocuğun adı "Ayşe", "Fatma" ya da "Hayriye", bize söylediğinde bize olasılık hakkında ek bir bilgi vermiyor, zaten çocuğu canlı görüyoruz ve Kapı-1 arkasında kız olduğu bilgisini öğreniyoruz.
* C durumu da B ile aynı, sunucu Kapı-2'yi seçecektir (çünkü biliyor).

Görüldüğü gibi 3 farklı durumda da sunucu bize ismi belli olan bir kız çocuğu göstermeyi başardı. Dolayısıyla hala her 3 durum da olmuş olabilir.

### Not/Düşünceler

Buradaki hile sunucunun kapıyı açarken "rastgele" değil, "erkek olmayacak şekilde" **bilinçli** açmasıdır. Bu problem bana Monty Hall problemini anımsattı. Orada da sunucunun "içerisinde keçi olduğunu zaten bildiği" bir kapıyı açması baştaki olasılıkları değiştirmiyordu. Bilmeyenler için: [Monty Hall problemi](https://tr.wikipedia.org/wiki/Monty_Hall_problemi).