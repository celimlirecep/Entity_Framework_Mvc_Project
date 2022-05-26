using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_01
{
    class Program
    {
        static void Main(string[] args)
        {
            //tolist ile çağırma
          void BolumleriListele()
            {
                HastaneSabahEntities hastane = new HastaneSabahEntities();
                var bolumler = hastane.Bolumler.ToList();
                Console.WriteLine($"Bölüm ID\t Bolum Ad");
                foreach (var bolum in bolumler)
                {

                    Console.WriteLine($" {bolum.ID}\t\t{bolum.BolumAd}");
                }
                Console.ReadLine();
            }
          //  BolumleriListele();

            //where metodu ile çağırma
            void BolumleriGetir()
            {
                using (HastaneSabahEntities hastane = new HastaneSabahEntities())
                {
                  //  var sonuc = hastane.Bolumler.Where(x => x.BolumAd == "Diş");
                    var sonuc = hastane.Bolumler.Where(x => x.BolumAd.StartsWith("D"));
                    foreach (var item in sonuc)
                    {
                        Console.WriteLine($"BolumID: {item.ID} Bolüm Ad: {item.BolumAd}");
                    }
                    Console.ReadLine();

                 
                }
            }
          // BolumleriGetir();

            //Select ile veri çeköe

            void DoktorAdListe()
            {
                using (HastaneSabahEntities hastane=new HastaneSabahEntities())
                {
                    var adlar = hastane.Doktorlar.Select(x => x.AdSoyad);
                    Console.WriteLine($"doktorlar Ad");
                    foreach (var item in adlar)
                    {
                        Console.WriteLine(item);
                    }
                    Console.ReadLine();
                }
            }
          //  DoktorAdListe();

            //Find ile hızlı arama
            void HizliAra()
            {
                using (HastaneSabahEntities hastane =new HastaneSabahEntities())
                {
                    Doktorlar doktor = hastane.Doktorlar.Find(4);
                    //ilgili tablodaki primary ket üzetinden arama yapar
                    Console.WriteLine($"doktor adı:{doktor.AdSoyad} Doktor Bölümü:{doktor.Bolumler.BolumAd}");
                }
                Console.ReadLine();
            }
            //HizliAra();

            //ilk kaydı getirme
            void IlkKayit()
            {
                using (HastaneSabahEntities hastane =new HastaneSabahEntities())
                {
                    Doktorlar doktor = hastane.Doktorlar
                        .Where(x => x.AdSoyad == "Demet Evgar")
                        .First();
                        
                    Console.WriteLine($"Doktor ad:{doktor.AdSoyad} bolümad:{doktor.Bolumler.BolumAd}");
                }
                Console.ReadLine();
            }
          //  IlkKayit();

            //ilk üç veriyi getir
            void IlkUcDoktoruGetir()
            {
                using (HastaneSabahEntities hastane=new HastaneSabahEntities())
                {
                    var ilkUcDoktor = hastane.Doktorlar.Take(3);
                    foreach (var doktor in ilkUcDoktor)
                    {
                        Console.WriteLine($"{doktor.AdSoyad}");
                    }
                    Console.ReadLine();
                        
                }
            }
          //  IlkUcDoktoruGetir();

            //varmi
            void VarMi()
            {
                using (HastaneSabahEntities hastane=new HastaneSabahEntities())
                {
                    bool sonuc = hastane.Doktorlar.Any(x => x.AdSoyad == "Demet Evgar");
                    if (sonuc)
                    {
                        Console.WriteLine("aradığınız doktor var");
                    }
                    else
                    {
                        Console.WriteLine("aradığınız doktor yook");
                    }
                    Console.ReadLine();
                }

            }
          //  VarMi();

            //uyuyormu

            void UyuyorMu()
            {
                using (HastaneSabahEntities hastane=new HastaneSabahEntities())
                {
                    bool sonuc = hastane.Doktorlar.All(x => x.BolumID ==1);
                    if (sonuc)
                    {
                        Console.WriteLine("aynı ");
                    }
                    else
                    {
                        Console.WriteLine("farklı");

                    }
                    Console.ReadLine();
                }

            }
          //  UyuyorMu();


            //a dan z ye sıralkama(ascending sıralama)

            void SiralaAsc()
            {
                using (HastaneSabahEntities hastane=new HastaneSabahEntities())
                {
                    var siraliDoktorlar = hastane.Doktorlar.OrderBy(x => x.AdSoyad);
                    foreach (var doktorlar in siraliDoktorlar)
                    {
                        Console.WriteLine(doktorlar.AdSoyad);
                    }
                    Console.ReadLine();
                }
            }
           // SiralaAsc();


            //descending sıralama
            void SiralaDesc()
            {
                using (HastaneSabahEntities hastane=new HastaneSabahEntities())
                {
                    var tersSiraliDoktorlar = hastane.Doktorlar.OrderByDescending(x => x.AdSoyad);
                    foreach (var doktor in tersSiraliDoktorlar)
                    {
                        Console.WriteLine(doktor.AdSoyad);
                    }
                    Console.ReadLine();
                }
            }
          //  SiralaDesc();


            //Son üç doktrou getir

            void SonUCDoktoruSirala()
            {
                using (HastaneSabahEntities hastane=new HastaneSabahEntities())
                {
                    var sonTersUCDoktor = hastane.Doktorlar.OrderByDescending(x => x.ID).Take(3);

                    foreach (var item in sonTersUCDoktor)
                    {
                        Console.WriteLine(item.AdSoyad);
                    }
                    Console.ReadLine();
                }
            }
          //  SonUCDoktoruSirala();

            //Bolümlere göre doktor sayısı

            void BolumlereGOreDoktorSayisi()
            {
                using (HastaneSabahEntities hastane=new HastaneSabahEntities())
                {
                    var sonuc = hastane.Doktorlar
                        .GroupBy(a => a.Bolumler.BolumAd)
                        .Select(b => new
                        {
                            name = b.Key,
                            count = b.Count(),
                        }) ;
                    Console.WriteLine("Bolum\t Doktor Sayisi");
                    foreach (var item in sonuc)
                    {
                        Console.WriteLine($"{item.name}\t {item.count}");
                    }
                    Console.ReadLine();
                }
            }
            BolumlereGOreDoktorSayisi();


        }
    }
}
