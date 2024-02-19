using System.Collections;
using System.Drawing.Text;
using System.Runtime.Intrinsics.X86;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Görüntü_İşleme_Projesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string imgepath = "";
        Bitmap foto;
        Bitmap orijinal;
        Bitmap grayscale;
        Bitmap thresholded;
        Bitmap negative;
        Bitmap grayNegative;
        Bitmap kontrastGerilme;
        Bitmap gaussian;
        Bitmap orta;
        Bitmap med;
        Bitmap laplased;
        Bitmap sobelx, sobely, sobelxy;
        Bitmap prewitted;
        Bitmap dndr;
        Bitmap aynaD;
        Bitmap aynaY;
        Bitmap otelen;
        Bitmap zoomO;
        Bitmap zoomI;
        Bitmap netlestir;
        Bitmap prespekt;
        Bitmap parlaklik;
        Bitmap kontrastImg;

        private void rgb2gray(Bitmap imge)
        {
            grayscale = new Bitmap(imge);//işlem ve sonuç aynı bmp
            int width = grayscale.Width;//resmin genişliği
            int height = grayscale.Height;//resmin yüksekliği
            Color p;//pixel
            for (int x = 0; x < height; x++)//x=resmin satır sayısı
                for (int y = 0; y < width; y++)//y=resmin sütun sayısı
                {
                    p = grayscale.GetPixel(x, y);//(x,y)deki pixeli al
                    int r = Convert.ToInt32((p.R) * 0.114);
                    int g = Convert.ToInt32((p.G) * 0.587);
                    int b = Convert.ToInt32((p.B) * 0.299);
                    int avg = (r + g + b);//rgb ortalalması
                    grayscale.SetPixel(x, y, Color.FromArgb(avg, avg, avg));//elde edilen pixeli sonuç resmine yerleştir
                }
        }

        public Bitmap ParlakligiDegistir(Bitmap imge)
        {
            int R = 0, G = 0, B = 0, parlakDegeri=Convert.ToInt32(parlaklikTxt.Text); 
            Color OkunanRenk, DonusenRenk; 
            Bitmap GirisResmi, CikisResmi; 
            GirisResmi = new Bitmap(imge);
            int ResimGenisligi = GirisResmi.Width; 
            int ResimYuksekligi = GirisResmi.Height; 
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); 
            
            int i = 0, j = 0; 
            for (int x = 0; x < ResimGenisligi; x++) 
            { j = 0; 
                for (int y = 0; y < ResimYuksekligi; y++) 
                { OkunanRenk = GirisResmi.GetPixel(x, y); 
                  R = OkunanRenk.R + parlakDegeri; 
                  G = OkunanRenk.G + parlakDegeri;
                  B = OkunanRenk.B + parlakDegeri;
                 
                 if (R > 255) R = 255; 
                 if (G > 255) G = 255;
                 if (B > 255) B = 255;
                 DonusenRenk = Color.FromArgb(R, G, B); 
                 CikisResmi.SetPixel(i, j, DonusenRenk); j++;
                }
                i++; 
            }
            parlaklik = new Bitmap(CikisResmi);
            return parlaklik;
        }

        private void kontrast(Bitmap imge)
        {
            int R = 0, G = 0, B = 0;
            Color OkunanRenk, DonusenRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(imge);
            int ResimGenisligi = GirisResmi.Width; 
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi); 
            double C_KontrastSeviyesi = Convert.ToInt32(kontrastTxt.Text);
            double F_KontrastFaktoru = (259 * (C_KontrastSeviyesi + 255)) / (255 * (259 - C_KontrastSeviyesi));
            for (int x = 0; x < ResimGenisligi; x++)
            {
                for (int y = 0; y < ResimYuksekligi; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    R = OkunanRenk.R;
                    G = OkunanRenk.G;
                    B = OkunanRenk.B;
                    R = (int)((F_KontrastFaktoru * (R - 128)) + 128);
                    G = (int)((F_KontrastFaktoru * (G - 128)) + 128);
                    B = (int)((F_KontrastFaktoru * (B - 128)) + 128);
                    
                    if (R > 255) R = 255;
                    if (G > 255) G = 255;
                    if (B > 255) B = 255;
                    if (R < 0) R = 0;
                    if (G < 0) G = 0;
                    if (B < 0) B = 0;
                    DonusenRenk = Color.FromArgb(R, G, B);
                    CikisResmi.SetPixel(x, y, DonusenRenk);
                }
            }
            kontrastImg = new Bitmap (CikisResmi);
        }


        private void laplas(Bitmap imge)
        {
            Color p;
            Bitmap islem = new Bitmap(imge);
            int width = islem.Width;
            int height = islem.Height;
            laplased = new Bitmap(width, height);
            int by = 3;
            int x, y, i, j, m, r, g, b, ort, yort;
            int[] Matris = {0, 1, 0, 1, -4, 1, 0, 1, 0};
            for (x = (by - 1) / 2; x < width - (by - 1) / 2; x++)
            {
                for (y = (by - 1) / 2; y < height - (by - 1) / 2; y++)
                {
                    yort = 0;
                    m = 0;
                    for (i = x - 1; i < x + 1; i++)
                    {
                        for (j = y - 1; j < y + 1; j++)
                        {
                            p = islem.GetPixel(i, j);
                            r = p.R;
                            g = p.G;
                            b = p.B;
                            ort = Convert.ToInt32((r + g + b)/3);
                            yort += ort * Matris[m];
                            m++;
                        }
                    }
                    if (yort > 255) yort=255;
                    if(yort < 0) yort=0;
                    laplased.SetPixel(x, y, Color.FromArgb(yort, yort, yort));
                }
            }
        }

        private void sobel(Bitmap imge)
        {
            Bitmap islem = new Bitmap(imge);
            int genislik = islem.Width;
            int yukseklik = islem.Height;
            sobelx = new Bitmap(genislik, yukseklik);
            sobely = new Bitmap(genislik, yukseklik);
            sobelxy = new Bitmap(genislik, yukseklik);
            int by = 3;
            int x, y;
            Color p;
            int P1, P2, P3, P4, P5, P6, P7, P8, P9;
            for (x = (by - 1) / 2; x < genislik - (by - 1) / 2; x++)
            {
                for (y = (by - 1) / 2; y < yukseklik - (by - 1) / 2; y++)
                {
                    p = islem.GetPixel(x - 1, y - 1);
                    P1 = (p.R + p.G + p.B) / 3;
                    p = islem.GetPixel(x, y - 1);
                    P2 = (p.R + p.G + p.B) / 3;
                    p = islem.GetPixel(x + 1, y - 1);
                    P3 = (p.R + p.G + p.B) / 3;
                    p = islem.GetPixel(x - 1, y);
                    P4 = (p.R + p.G + p.B) / 3;
                    p = islem.GetPixel(x, y);
                    P5 = (p.R + p.G + p.B) / 3;
                    p = islem.GetPixel(x + 1, y);
                    P6 = (p.R + p.G + p.B) / 3;
                    p = islem.GetPixel(x - 1, y + 1);
                    P7 = (p.R + p.G + p.B) / 3;
                    p = islem.GetPixel(x, y + 1);
                    P8 = (p.R + p.G + p.B) / 3;
                    p = islem.GetPixel(x + 1, y + 1);
                    P9 = (p.R + p.G + p.B) / 3;
                    int Gx = Math.Abs(-P1 + P3 - 2 * P4 + 2 * P6 - P7 + P9);
                    int Gy = Math.Abs(P1 + 2 * P2 + P3 - P7 - 2 * P8 - P9);
                    int Gxy = Gx + Gy;
                    if (Gx > 255) Gx = 255;
                    if (Gy > 255) Gy = 255;
                    if (Gxy > 255) Gxy = 255;
                    sobelx.SetPixel(x, y, Color.FromArgb(Gx, Gx, Gx));
                    sobely.SetPixel(x, y, Color.FromArgb(Gy, Gy, Gy));
                    sobelxy.SetPixel(x, y, Color.FromArgb(Gxy, Gxy, Gxy));
                }
            }
        }

        private void prewitt(Bitmap imge)
        {
            Bitmap islem = new Bitmap(imge);//işlem ve sonuç aynı bmp
            int genislik = islem.Width;//resmin genişliği
            int yukseklik = islem.Height;//resmin yüksekliği
            prewitted = new Bitmap(genislik, yukseklik);
            int by = 3;//matrisin boyutu
            int ElemanSayisi = by * by;
            int x, y;
            Color p;//çalışılacak pixel
            int P1, P2, P3, P4, P5, P6, P7, P8, P9;//maske üzerindeki pixel rgb ortalaması
            for (x = (by - 1) / 2; x < genislik - (by - 1) / 2; x++) //x=resmin satır sayısı
            {
                for (y = (by - 1) / 2; y < yukseklik - (by - 1) / 2; y++)//y=resmin sütun sayısı
                {
                    p = islem.GetPixel(x - 1, y - 1);
                    P1 = (p.R + p.G + p.B) / 3;
                    p = islem.GetPixel(x, y - 1);
                    P2 = (p.R + p.G + p.B) / 3;
                    p = islem.GetPixel(x + 1, y - 1);
                    P3 = (p.R + p.G + p.B) / 3;
                    p = islem.GetPixel(x - 1, y);
                    P4 = (p.R + p.G + p.B) / 3;
                    p = islem.GetPixel(x, y);
                    P5 = (p.R + p.G + p.B) / 3;
                    p = islem.GetPixel(x + 1, y);
                    P6 = (p.R + p.G + p.B) / 3;
                    p = islem.GetPixel(x - 1, y + 1);
                    P7 = (p.R + p.G + p.B) / 3;
                    p = islem.GetPixel(x, y + 1);
                    P8 = (p.R + p.G + p.B) / 3;
                    p = islem.GetPixel(x + 1, y + 1);
                    P9 = (p.R + p.G + p.B) / 3;
                    int Gx = Math.Abs(-P1 + P3 - P4 + P6 - P7 + P9); //yatay operatörü hesapla
                    int Gy = Math.Abs(P1 + P2 + P3 - P7 - P8 - P9); //dikey operatörü hesapla
                    int PrewittDegeri = 0;
                    PrewittDegeri = Gx;
                    PrewittDegeri = Gy;
                    PrewittDegeri = Gx + Gy;
                    if (PrewittDegeri > 255) PrewittDegeri = 255;
                    prewitted.SetPixel(x, y, Color.FromArgb(PrewittDegeri, PrewittDegeri, PrewittDegeri));//elde edilen pixeli sonuç resmine yerleştir
                }
            }
        }

        private void gauss(Bitmap imge)
        {
            Color OkunanRenk;
            Bitmap GirisResmi, CikisResmi;
            GirisResmi = new Bitmap(imge);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = 5; //Çekirdek matrisin boyutu
            int ElemanSayisi = SablonBoyutu * SablonBoyutu;
            int x, y, i, j, toplamR, toplamG, toplamB, ortalamaR, ortalamaG, ortalamaB;
            int[] Matris = { 1, 4, 6, 4, 1, 4, 16, 24, 16, 4, 6, 24, 36, 24, 6, 4, 16, 24, 16, 4, 1, 4, 6, 4, 1 };
            int MatrisToplami = 1+ 4+ 6+ 4+ 1+ 4+ 16+ 24+ 16+ 4+ 6+ 24+ 36+ 24+ 6+ 4+ 16+ 24+ 16+ 4+ 1+ 4+ 6+ 4+ 1;
            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++) //Resmitaramaya şablonun yarısı kadar dış kenarlardan içeride başlayacak ve bitirecek.
{
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    toplamR = 0;
                    toplamG = 0;
                    toplamB = 0;
                    //Şablon bölgesi (çekirdek matris) içindeki pikselleri tarıyor.
                    int k = 0; //matris içindeki elemanları sırayla okurken kullanılacak.
                    for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                    {
                        for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                        {
                            OkunanRenk = GirisResmi.GetPixel(x + i, y + j);
                            toplamR = toplamR + OkunanRenk.R * Matris[k];
                            toplamG = toplamG + OkunanRenk.G * Matris[k];
                            toplamB = toplamB + OkunanRenk.B * Matris[k];
                            k++;
                        }
                    }
                    ortalamaR = toplamR / MatrisToplami;
                    ortalamaG = toplamG / MatrisToplami;
                    ortalamaB = toplamB / MatrisToplami;
                    CikisResmi.SetPixel(x, y, Color.FromArgb(ortalamaR, ortalamaG, ortalamaB));
                }
            }
            gaussian = CikisResmi;

        }

            private void thresholding(Bitmap imge)
            {
                thresholded = new Bitmap(imge);//işlem ve sonuç aynı bmp
                int width = thresholded.Width;//resmin genişliği
                int height = thresholded.Height;//resmin yüksekliği
                Color p;//işlenecek pixel
                for (int y = 0; y < height; y++)//y=resmin sütun sayısı
                    for (int x = 0; x < width; x++)//x=resmin satır sayısı
                    {
                        p = thresholded.GetPixel(x, y);
                        int er = p.R;//eski kırmızı
                        int eg = p.G;//eski yeşil
                        int eb = p.B;//eski mavi
                        int eavg = (er + eg + eb) / 3;//eski rgb ortalaması
                        int r = Convert.ToInt32((p.R) * 0.114);//yeni kırmızı
                        int g = Convert.ToInt32((p.G) * 0.587);//yeni yeşil
                        int b = Convert.ToInt32((p.B) * 0.299);//yeni mavi
                        if(eavg>= 100)//thresholding point
                            thresholded.SetPixel(x, y, Color.FromArgb(255, 255, 255));//elde edilen pixeli sonuç resmine yerleştir
                        else thresholded.SetPixel(x, y, Color.FromArgb(0, 0, 0));//elde edilen pixeli sonuç resmine yerleştir
                    }
            }

        private void makeNeg(Bitmap imge)
        {
            negative = new Bitmap(imge);//işlem ve sonuç aynı bmp
            int width = negative.Width;//resmin genişliği
            int height = negative.Height;//resmin yüksekliği
            Color p;//işlenecek pixel
            for (int y = 0; y < height; y++)// y = resmin sütun sayısı
                for (int x = 0; x < width; x++)//x=resmin satır sayısı
                {
                    p = negative.GetPixel(x, y);
                    int er = p.R;//eski kırmızı
                    int eg = p.G;//eski yeşil
                    int eb = p.B;//eski yeşil
                    negative.SetPixel(x, y, Color.FromArgb(255-er, 255-eg, 255-eb));//elde edilen pixeli sonuç resme yerleştir
                }
        }

        private void makeGrayNeg()
        {
            grayNegative = new Bitmap(grayscale);//görüntüyü grayscale dönüştür sonra aynı bmp üzerinde devam et
            int width = grayNegative.Width;//resmin genişliği
            int height = grayNegative.Height;//resmin yüksekliği
            Color p;//işlenecek pixel
            for (int y = 0; y < height; y++)// y = resmin sütun sayısı
                for (int x = 0; x < width; x++)//x=resmin satır sayısı
                {
                    p = grayNegative.GetPixel(x, y);
                    int er = p.R;//eski kırmızı
                    int eg = p.G;//eski yeşil
                    int eb = p.B;//eski mavi
                    grayNegative.SetPixel(x, y, Color.FromArgb(255 - er, 255 - eg, 255 - eb));//elde edilen pixeli sonuç resme yerleştir
                }
        }

        private void kontrastgerme(Bitmap imge)
        {
            kontrastGerilme = new Bitmap(imge);//işlem ve sonuç aynı bmp
            int width = kontrastGerilme.Width;//resmin genişliği
            int height = kontrastGerilme.Height;//resmin yüksekliği
            Color p;//işlenecek pixel
            int min = 0, max = 0;//min. ve max gri seviyeleri
            for (int y = 0; y < height; y++)// y = resmin sütun sayısı
                for (int x = 0; x < width; x++)//x=resmin satır sayısı
                {
                    p = kontrastGerilme.GetPixel(x, y);
                    int er = p.R;//eski kırmızı
                    int eg = p.G;//eski yeşil
                    int eb = p.B;//eski mavi
                    int eavg = (er + eg + eb) / 3;//eski rgb ortalama
                    if (eavg < min)//min. gri seviyesini bul
                        min = eavg;
                    if (eavg > max)//max. gri seviyesini bul
                        max = eavg;
                }

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    p = kontrastGerilme.GetPixel(x, y);
                    int er = p.R;
                    int eg = p.G;
                    int eb = p.B;
                    int eavg = (er + eg + eb) / 3;
                    int yavg = ((eavg-min)*255)/(max-min);//yeni gri seviyesi
                    kontrastGerilme.SetPixel(x, y, Color.FromArgb(yavg, yavg, yavg));//elde edilen pixeli sonuç resme yerleştir
                }
        }

        private void ortalama(Bitmap imge)
        {
            Color p;//işlenecek pixel
            orta = new Bitmap(imge);//işlem ve sonuç aynı bmp
            int width = orta.Width;//resmin genişliği
            int height = orta.Height;//resmin yüksekliği
            int by = 5;//matris boyutu
            int x, y, i, j, toplamR, toplamG, toplamB, ortalamaR, ortalamaG, ortalamaB;
            for (x = (by - 1) / 2; x < width - (by - 1) / 2; x++)//x=resmin satır sayısı
            {
                for (y = (by - 1) / 2; y < height - (by - 1) / 2; y++)//y=resmin sütun sayısı
                {
                    toplamR = 0;
                    toplamG = 0;
                    toplamB = 0;
                    for (i = -((by - 1) / 2); i <= (by - 1) / 2; i++)//x=matrisin satır sayısı
                    {
                        for (j = -((by - 1) / 2); j <= (by - 1) / 2; j++)//y=matrisin sütun sayısı
                        {
                            p = orta.GetPixel(x + i, y + j);
                            toplamR = toplamR + p.R;
                            toplamG = toplamG + p.G;
                            toplamB = toplamB + p.B;
                        }
                    }
                    ortalamaR = toplamR / (by * by);
                    ortalamaG = toplamG / (by * by);
                    ortalamaB = toplamB / (by * by);
                    orta.SetPixel(x, y, Color.FromArgb(ortalamaR, ortalamaG, ortalamaB));//elde edilen pixeli sonuç resme yerleştir
                }
            }
        }

        private void aynalamaDikey(Bitmap imge)
        {

            Color OkunanRenk;
            Bitmap islem;
            islem = new Bitmap(imge);
            int ResimGenisligi = islem.Width;
            int ResimYuksekligi = islem.Height;
            aynaD = new Bitmap(ResimGenisligi, ResimYuksekligi);
       
            double x2 = 0, y2 = 0;
            //Resim merkezini buluyor. Resim merkezi etrafında döndürecek. 
            int x0 = ResimGenisligi / 2;
            int y0 = ResimYuksekligi / 2;
            for (int x1 = 0; x1 < (ResimGenisligi); x1++)
            {
                for (int y1 = 0; y1 < (ResimYuksekligi); y1++)
                {
                    OkunanRenk = islem.GetPixel(x1, y1);
                    //----A-Orta dikey eksen etrafında aynalama ----------------
                    x2 = Convert.ToInt16(-x1 + 2 * x0);
                    y2 = Convert.ToInt16(y1);
                    //----B-Orta yatay eksen etrafında aynalama ----------------
                    //x2 = Convert.ToInt16(x1);
                    //y2 = Convert.ToInt16(-y1 + 2 *y0);

                    //----C-Ortadan geçen 45 açılı çizgi etrafında aynalama----------
                    //double Delta = (x1 - x0) * Math.Sin(RadyanAci) - (y1 - y0) * Math.Cos(RadyanAci);
                    //x2 = Convert.ToInt16(x1 + 2 * Delta * (-Math.Sin(RadyanAci)));
                    //y2 = Convert.ToInt16(y1 + 2 * Delta * (Math.Cos(RadyanAci)));
                    if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                        aynaD.SetPixel((int)x2, (int)y2, OkunanRenk);
                }
            }
        }

        private void aynalamaYatay(Bitmap imge)
        {
            Color OkunanRenk;
            Bitmap islem;
            islem = new Bitmap(imge);
            int ResimGenisligi = islem.Width;
            int ResimYuksekligi = islem.Height;
            aynaY = new Bitmap(ResimGenisligi, ResimYuksekligi);

            double x2 = 0, y2 = 0;
            //Resim merkezini buluyor. Resim merkezi etrafında döndürecek. 
            int x0 = ResimGenisligi / 2;
            int y0 = ResimYuksekligi / 2;
            for (int x1 = 0; x1 < (ResimGenisligi); x1++)
            {
                for (int y1 = 0; y1 < (ResimYuksekligi); y1++)
                {
                    OkunanRenk = islem.GetPixel(x1, y1);
                    //----A-Orta dikey eksen etrafında aynalama ----------------
                    //x2 = Convert.ToInt16(-x1 + 2 * x0);
                    //y2 = Convert.ToInt16(y1);
                    //----B-Orta yatay eksen etrafında aynalama ----------------
                    x2 = Convert.ToInt16(x1);
                    y2 = Convert.ToInt16(-y1 + 2 * y0);

                    //----C-Ortadan geçen 45 açılı çizgi etrafında aynalama----------
                    //double Delta = (x1 - x0) * Math.Sin(RadyanAci) - (y1 - y0) * Math.Cos(RadyanAci);
                    //x2 = Convert.ToInt16(x1 + 2 * Delta * (-Math.Sin(RadyanAci)));
                    //y2 = Convert.ToInt16(y1 + 2 * Delta * (Math.Cos(RadyanAci)));
                    if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                        aynaY.SetPixel((int)x2, (int)y2, OkunanRenk);
                }
            }
        }

        private void oteleme(Bitmap imge)
        {
            Color OkunanRenk;
            Bitmap islem;
            islem = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = islem.Width;
            int ResimYuksekligi = islem.Height;
            otelen = new Bitmap(ResimGenisligi, ResimYuksekligi);
            double x2 = 0, y2 = 0;
            //Taşıma mesafelerini atıyor. 
            int Tx = Convert.ToInt16(otelemeX.Text);
            int Ty = Convert.ToInt16(otelemeY.Text);
            for (int x1 = 0; x1 < (ResimGenisligi); x1++)
            {
                for (int y1 = 0; y1 < (ResimYuksekligi); y1++)
                {
                    OkunanRenk = islem.GetPixel(x1, y1);
                    x2 = x1 + Tx;
                    y2 = y1 + Ty;
                    if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                        otelen.SetPixel((int)x2, (int)y2, OkunanRenk);
                }
            }
        }

        private void dondur(Bitmap imge)
        {
            Color OkunanRenk;
            Bitmap islem = new Bitmap(imge);
            int ResimGenisligi = islem.Width;
            int ResimYuksekligi = islem.Height;
            dndr = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int Aci = Convert.ToInt16(aci_Box.Text);
            double RadyanAci = Aci * 2 * Math.PI / 360;
            double x2 = 0, y2 = 0;
            //Resim merkezini buluyor. Resim merkezi etrafında döndürecek. 
            int x0 = ResimGenisligi / 2;
            int y0 = ResimYuksekligi / 2;
            for (int x1 = 0; x1 < (ResimGenisligi); x1++)
            {
                for (int y1 = 0; y1 < (ResimYuksekligi); y1++)
                {
                    OkunanRenk = islem.GetPixel(x1, y1);
                    //Döndürme Formülleri
                    x2 = Math.Cos(RadyanAci) * (x1 - x0) - Math.Sin(RadyanAci) * (y1 - y0) + x0;
                    y2 = Math.Sin(RadyanAci) * (x1 - x0) + Math.Cos(RadyanAci) * (y1 - y0) + y0;
                    if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                        dndr.SetPixel((int)x2, (int)y2, OkunanRenk);
                }
            }
        }

        private void zoomOut(Bitmap imge)
        {
            Color OkunanRenk;
            Bitmap islem;
            islem = new Bitmap(imge);
            int ResimGenisligi = islem.Width;
            int ResimYuksekligi = islem.Height;
            zoomO = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int x2 = 0, y2 = 0; //Çıkış resminin x ve y si olacak.
            int KucultmeKatsayisi = 2;
            for (int x1 = 0; x1 < ResimGenisligi; x1 = x1 + KucultmeKatsayisi)
            {
                y2 = 0;
                for (int y1 = 0; y1 < ResimYuksekligi; y1 = y1 + KucultmeKatsayisi)
                {
                    OkunanRenk = islem.GetPixel(x1, y1);
                    zoomO.SetPixel(x2, y2, OkunanRenk);
                    y2++;
                }
                x2++;
            }
        }

        private void zoomIn(Bitmap imge)
        {
            Color OkunanRenk;
            Bitmap islem;
            islem = new Bitmap(imge);
            int ResimGenisligi = islem.Width;
            int ResimYuksekligi = islem.Height;
            zoomI = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int BuyutmeKatsayisi = 2;
            int x2 = 0, y2 = 0;
            for (int x1 = 0; x1 < ResimGenisligi; x1++)
            {
                for (int y1 = 0; y1 < ResimYuksekligi; y1++)
                {
                    OkunanRenk = islem.GetPixel(x1, y1);
                    for (int i = 0; i < BuyutmeKatsayisi; i++)
                    {
                        for (int j = 0; j < BuyutmeKatsayisi; j++)
                        {
                            x2 = x1 * BuyutmeKatsayisi + i;
                            y2 = y1 * BuyutmeKatsayisi + j;
                        }
                        if (x2 > 0 && x2 < ResimGenisligi && y2 > 0 && y2 < ResimYuksekligi)
                            zoomI.SetPixel(x2, y2, OkunanRenk);
                    }
                }
            }
        }

        public double[,] MatrisTersiniAl (double[,] GirisMatrisi)
        {
            int MatrisBoyutu = Convert.ToInt16(Math.Sqrt(GirisMatrisi.Length)); //matris boyutu içindeki eleman sayısı olduğu için kare matrisde karekökü matris boyutu olur.
            double[,] CikisMatrisi = new double[MatrisBoyutu, MatrisBoyutu]; //A nın tersi alındığında bu matris içinde tutulacak.
                                                                             //--I Birim matrisin içeriğini dolduruyor
            for (int i = 0; i < MatrisBoyutu; i++)
            {
                for (int j = 0; j < MatrisBoyutu; j++)
                {
                    if (i == j)
                        CikisMatrisi[i, j] = 1;
                    else CikisMatrisi[i, j] = 0;
                }
            }
            //--Matris Tersini alma işlemi---------
            double d, k;
            for (int i = 0; i < MatrisBoyutu; i++)
            {
                d = GirisMatrisi[i, i];
                for (int j = 0; j < MatrisBoyutu; j++)
                {
                    if (d == 0)
                    {
                        d = 0.0001; //0 bölme hata veriyordu.
                    } 
                    GirisMatrisi[i, j] = GirisMatrisi[i, j] / d; 
                    CikisMatrisi[i, j] = CikisMatrisi[i, j] / d; 
                } 
                for (int x = 0; x < MatrisBoyutu; x++) 
                { if (x != i) 
                    { k = GirisMatrisi[x, i]; 
                        for (int j = 0; j < MatrisBoyutu; j++) { GirisMatrisi[x, j] = GirisMatrisi[x, j] - GirisMatrisi[i, j] * k; CikisMatrisi[x, j] = CikisMatrisi[x, j] - CikisMatrisi[i, j] * k; 
                        } 
                    } 
                } 
            }
                        return CikisMatrisi; 
        }

        private void prespektif(Bitmap imge)
        {
            double x1 = Convert.ToDouble(x1txt.Text);
            double y1 = Convert.ToDouble(y1txt.Text);
            double x2 = Convert.ToDouble(x2txt.Text);
            double y2 = Convert.ToDouble(y2txt.Text);
            double x3 = Convert.ToDouble(x3txt.Text);
            double y3 = Convert.ToDouble(y3txt.Text);
            double x4 = Convert.ToDouble(x4txt.Text);
            double y4 = Convert.ToDouble(y4txt.Text);
            double X1 = Convert.ToDouble(X11txt.Text);
            double Y1 = Convert.ToDouble(Y11txt.Text);
            double X2 = Convert.ToDouble(X22txt.Text);
            double Y2 = Convert.ToDouble(Y22txt.Text);
            double X3 = Convert.ToDouble(X33txt.Text);
            double Y3 = Convert.ToDouble(Y33txt.Text);
            double X4 = Convert.ToDouble(X44txt.Text);
            double Y4 = Convert.ToDouble(Y44txt.Text);

            double[,] GirisMatrisi = new double[8, 8];
            // { x1, y1, 1, 0, 0, 0, -x1 * X1, -y1 * X1 }
            GirisMatrisi[0, 0] = x1;
            GirisMatrisi[0, 1] = y1;
            GirisMatrisi[0, 2] = 1;
            GirisMatrisi[0, 3] = 0;
            GirisMatrisi[0, 4] = 0;
            GirisMatrisi[0, 5] = 0;
            GirisMatrisi[0, 6] = -x1 * X1;
            GirisMatrisi[0, 7] = -y1 * X1;

            //{ 0, 0, 0, x1, y1, 1, -x1 * Y1, -y1 * Y1 }
            GirisMatrisi[1, 0] = 0;
            GirisMatrisi[1, 1] = 0;
            GirisMatrisi[1, 2] = 0;
            GirisMatrisi[1, 3] = x1;
            GirisMatrisi[1, 4] = y1;
            GirisMatrisi[1, 5] = 1;
            GirisMatrisi[1, 6] = -x1 * Y1;
            GirisMatrisi[1, 7] = -y1 * Y1;
            //{ x2, y2, 1, 0, 0, 0, -x2 * X2, -y2 * X2 }
            GirisMatrisi[2, 0] = x2;
            GirisMatrisi[2, 1] = y2;
            GirisMatrisi[2, 2] = 1;
            GirisMatrisi[2, 3] = 0;
            GirisMatrisi[2, 4] = 0;
            GirisMatrisi[2, 5] = 0;
            GirisMatrisi[2, 6] = -x2 * X2;
            GirisMatrisi[2, 7] = -y2 * X2;
            //{ 0, 0, 0, x2, y2, 1, -x2 * Y2, -y2 * Y2 }
            GirisMatrisi[3, 0] = 0;
            GirisMatrisi[3, 1] = 0;
            GirisMatrisi[3, 2] = 0;
            GirisMatrisi[3, 3] = x2;
            GirisMatrisi[3, 4] = y2;
            GirisMatrisi[3, 5] = 1;
            GirisMatrisi[3, 6] = -x2 * Y2;
            GirisMatrisi[3, 7] = -y2 * Y2;
            //{ x3, y3, 1, 0, 0, 0, -x3 * X3, -y3 * X3 }
            GirisMatrisi[4, 0] = x3;
            GirisMatrisi[4, 1] = y3;
            GirisMatrisi[4, 2] = 1;
            GirisMatrisi[4, 3] = 0;
            GirisMatrisi[4, 4] = 0;
            GirisMatrisi[4, 5] = 0;
            GirisMatrisi[4, 6] = -x3 * X3;
            GirisMatrisi[4, 7] = -y3 * X3;
            //{ 0, 0, 0, x3, y3, 1, -x3 * Y3, -y3 * Y3 }
            GirisMatrisi[5, 0] = 0;
            GirisMatrisi[5, 1] = 0;
            GirisMatrisi[5, 2] = 0;
            GirisMatrisi[5, 3] = x3;
            GirisMatrisi[5, 4] = y3;
            GirisMatrisi[5, 5] = 1;
            GirisMatrisi[5, 6] = -x3 * Y3;
            GirisMatrisi[5, 7] = -y3 * Y3;
            //{ x4, y4, 1, 0, 0, 0, -x4 * X4, -y4 * X4 }
            GirisMatrisi[6, 0] = x4;
            GirisMatrisi[6, 1] = y4;
            GirisMatrisi[6, 2] = 1;
            GirisMatrisi[6, 3] = 0;
            GirisMatrisi[6, 4] = 0;
            GirisMatrisi[6, 5] = 0;
            GirisMatrisi[6, 6] = -x4 * X4;
            GirisMatrisi[6, 7] = -y4 * X4;
            //{ 0, 0, 0, x4, y4, 1, -x4 * Y4, -y4 * Y4 }
            GirisMatrisi[7, 0] = 0;
            GirisMatrisi[7, 1] = 0;
            GirisMatrisi[7, 2] = 0;
            GirisMatrisi[7, 3] = x4;
            GirisMatrisi[7, 4] = y4;
            GirisMatrisi[7, 5] = 1;
            GirisMatrisi[7, 6] = -x4 * Y4;
            GirisMatrisi[7, 7] = -y4 * Y4;

            //---------------------------------------------------------------------------
            double[,] matrisBTersi = MatrisTersiniAl(GirisMatrisi);
            //----------------------------------- A Dönüşüm Matrisi (3x3) ---------------

            double a00 = 0, a01 = 0, a02 = 0, a10 = 0, a11 = 0, a12 = 0, a20 = 0, a21 = 0, a22 = 0;
            a00 = matrisBTersi[0, 0] * X1 + matrisBTersi[0, 1] * Y1 + matrisBTersi[0, 2] * X2 + matrisBTersi[0, 3] * Y2 + matrisBTersi[0, 4] * X3 + matrisBTersi[0, 5] * Y3 + matrisBTersi[0, 6] * X4 + matrisBTersi[0, 7] * Y4;
            a01 = matrisBTersi[1, 0] * X1 + matrisBTersi[1, 1] * Y1 + matrisBTersi[1, 2] * X2 + matrisBTersi[1, 3] * Y2 + matrisBTersi[1, 4] * X3 + matrisBTersi[1, 5] * Y3 + matrisBTersi[1, 6] * X4 + matrisBTersi[1, 7] * Y4;
            a02 = matrisBTersi[2, 0] * X1 + matrisBTersi[2, 1] * Y1 + matrisBTersi[2, 2] * X2 + matrisBTersi[2, 3] * Y2 + matrisBTersi[2, 4] * X3 + matrisBTersi[2, 5] * Y3 + matrisBTersi[2, 6] * X4 + matrisBTersi[2, 7] * Y4;
            a10 = matrisBTersi[3, 0] * X1 + matrisBTersi[3, 1] * Y1 + matrisBTersi[3, 2] * X2 + matrisBTersi[3, 3] * Y2 + matrisBTersi[3, 4] * X3 + matrisBTersi[3, 5] * Y3 + matrisBTersi[3, 6] * X4 + matrisBTersi[3, 7] * Y4;
            a11 = matrisBTersi[4, 0] * X1 + matrisBTersi[4, 1] * Y1 + matrisBTersi[4, 2] * X2 + matrisBTersi[4, 3] * Y2 + matrisBTersi[4, 4] * X3 + matrisBTersi[4, 5] * Y3 + matrisBTersi[4, 6] * X4 + matrisBTersi[4, 7] * Y4;
            a12 = matrisBTersi[5, 0] * X1 + matrisBTersi[5, 1] * Y1 + matrisBTersi[5, 2] * X2 + matrisBTersi[5, 3] * Y2 + matrisBTersi[5, 4] * X3 + matrisBTersi[5, 5] * Y3 + matrisBTersi[5, 6] * X4 + matrisBTersi[5, 7] * Y4;
            a20 = matrisBTersi[6, 0] * X1 + matrisBTersi[6, 1] * Y1 + matrisBTersi[6, 2] * X2 + matrisBTersi[6, 3] * Y2 + matrisBTersi[6, 4] * X3 + matrisBTersi[6, 5] * Y3 + matrisBTersi[6, 6] * X4 + matrisBTersi[6, 7] * Y4;
            a21 = matrisBTersi[7, 0] * X1 + matrisBTersi[7, 1] * Y1 + matrisBTersi[7, 2] * X2 + matrisBTersi[7, 3] * Y2 + matrisBTersi[7, 4] * X3 + matrisBTersi[7, 5] * Y3 + matrisBTersi[7, 6] * X4 + matrisBTersi[7, 7] * Y4;
            a22 = 1;
            //------------------------- Perspektif düzeltme işlemi --------------------------------
            PerspektifDuzelt(a00, a01, a02, a10, a11, a12, a20, a21, a22, imge);
        }

        public void PerspektifDuzelt(double a00, double a01, double a02, double a10, double a11, double a12, double a20, double a21, double a22, Bitmap imge)
        {
            Bitmap GirisResmi, CikisResmi;
            Color OkunanRenk;
            GirisResmi = new Bitmap(imge);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            CikisResmi = new Bitmap(ResimGenisligi, ResimYuksekligi);
            double X, Y, z;
            for (int x = 0; x < (ResimGenisligi); x++)
            {
                for (int y = 0; y < (ResimYuksekligi); y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    z = a20 * x + a21 * y + 1;
                    X = (a00 * x + a01 * y + a02) / z;
                    Y = (a10 * x + a11 * y + a12) / z;
                    if (X > 0 && X < ResimGenisligi && Y > 0 && Y < ResimYuksekligi) //Picturebox ın dışına çıkan kısımlar oluşturulmayacak.
                        CikisResmi.SetPixel((int)X, (int)Y, OkunanRenk);
                }
            }
            prespekt = CikisResmi;
        }

        private void netlestirme(Bitmap imge)
        {
            Color OkunanRenk;
            Bitmap islem;
            islem = new Bitmap(pictureBox1.Image);
            int ResimGenisligi = islem.Width; 
            int ResimYuksekligi = islem.Height;
            netlestir = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = 3; 
            int ElemanSayisi = SablonBoyutu * SablonBoyutu;
            int x, y, i, j, toplamR, toplamG, toplamB;
            int R, G, B;
            int[] Matris = { 0, -2, 0, -2, 11, -2, 0, -2, 0 }; 
            int MatrisToplami = 0 + -2 + 0 + -2 + 11 + -2 + 0 + -2 + 0;
            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++) //Resmi taramaya şablonun yarısı kadar dış kenarlardan içeride başlayacak ve bitirecek.
            {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    toplamR = 0; 
                    toplamG = 0; 
                    toplamB = 0;
                    //Şablon bölgesi (çekirdek matris) içindeki pikselleri tarıyor.
                    int k = 0;
                    //matris içindeki elemanları sırayla okurken kullanılacak.
                    for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                    {
                        for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                        {
                            OkunanRenk = islem.GetPixel(x + i, y + j);
                            toplamR = toplamR + OkunanRenk.R * Matris[k]; 
                            toplamG = toplamG + OkunanRenk.G * Matris[k]; 
                            toplamB = toplamB + OkunanRenk.B * Matris[k];
                            k++;
                        }
                    }
                    R = toplamR / MatrisToplami; 
                    G = toplamG / MatrisToplami; 
                    B = toplamB / MatrisToplami;
                    //=========================================================== 
                    //Renkler sınırların dışına çıktıysa, sınır değer alınacak.
                    if (R > 255) R = 255; 
                    if (G > 255) G = 255; 
                    if (B > 255) B = 255;

                    if (R < 0) R = 0; 
                    if (G < 0) G = 0; 
                    if (B < 0) B = 0; 
                    //===========================================================
                    netlestir.SetPixel(x, y, Color.FromArgb(R, G, B));
                }
            }
        }

        private void histogramHesapla(Bitmap imge)
        {
            ArrayList DiziPiksel = new ArrayList();
            int OrtalamaRenk = 0;
            Color OkunanRenk;
            Bitmap GirisResmi;
            GirisResmi = new Bitmap(imge);
            int ResimGenisligi = GirisResmi.Width;
            int ResimYuksekligi = GirisResmi.Height;
            for (int x = 0; x < GirisResmi.Width; x++)
            {
                for (int y = 0; y < GirisResmi.Height; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    OrtalamaRenk = (int)(OkunanRenk.R + OkunanRenk.G + OkunanRenk.B) / 3; //Griton resimde üç kanal  rengi aynı değere sahiptir.
                    DiziPiksel.Add(OrtalamaRenk); //Resimdeki tüm noktaları diziye atıyor. 
                }
            }
            int[] DiziPikselSayilari = new int[256];
            for (int r = 0; r <= 255; r++) //256 tane renk tonu için dönecek.
            {
                int PikselSayisi = 0;
                for (int s = 0; s < DiziPiksel.Count; s++) //resimdeki piksel sayısınca dönecek. 
                {
                    if (r == Convert.ToInt16(DiziPiksel[s]))
                        PikselSayisi++;
                }
                DiziPikselSayilari[r] = PikselSayisi;
            }
            //Değerleri listbox'a ekliyor. 
            int RenkMaksPikselSayisi = 0; //Grafikte y eksenini ölçeklerken kullanılacak. 
            for (int k = 0; k <= 255; k++)
            {
                listBox1.Items.Add("Renk:" + k + "=" + DiziPikselSayilari[k]);
                //Maksimum piksel sayısını bulmaya çalışıyor.
                if (DiziPikselSayilari[k] > RenkMaksPikselSayisi)
                {
                    RenkMaksPikselSayisi = DiziPikselSayilari[k];
                }
            }
            //Grafiği çiziyor. 
            Graphics CizimAlani;
            Pen Kalem1 = new Pen(System.Drawing.Color.Yellow, 1);
            Pen Kalem2 = new Pen(System.Drawing.Color.Red, 1);
            CizimAlani = pictureBox3.CreateGraphics();
            pictureBox3.Refresh();
            int GrafikYuksekligi = 300;
            double OlcekY = RenkMaksPikselSayisi / GrafikYuksekligi;
            double OlcekX = 1.5;
            int X_kaydirma = 10;
            for (int x = 0; x <= 255; x++)
            {
                if (x % 50 == 0)
                    CizimAlani.DrawLine(Kalem2, (int)(X_kaydirma + x * OlcekX),
                   GrafikYuksekligi, (int)(X_kaydirma + x * OlcekX), 0);
                CizimAlani.DrawLine(Kalem1, (int)(X_kaydirma + x * OlcekX), GrafikYuksekligi,
               (int)(X_kaydirma + x * OlcekX), (GrafikYuksekligi - (int)(DiziPikselSayilari[x] / OlcekY)));
                //Dikey kırmızı çizgiler.

            }
            textBox1.Text = "Maks.Piks=" + RenkMaksPikselSayisi.ToString();
        }

        private void medyan(Bitmap imge)
        {
            Color OkunanRenk;
            Bitmap islem = new Bitmap(imge);
            
            int ResimGenisligi = islem.Width;
            int ResimYuksekligi = islem.Height;
            med = new Bitmap(ResimGenisligi, ResimYuksekligi);
            int SablonBoyutu = 5; //şablon boyutu 3 den büyük tek rakam olmalıdır(3, 5, 7 gibi).
            int ElemanSayisi = SablonBoyutu * SablonBoyutu;
            int[] R = new int[ElemanSayisi];
            int[] G = new int[ElemanSayisi];
            int[] B = new int[ElemanSayisi];
            int[] Gri = new int[ElemanSayisi];
            int x, y, i, j;
            for (x = (SablonBoyutu - 1) / 2; x < ResimGenisligi - (SablonBoyutu - 1) / 2; x++)
            {
                for (y = (SablonBoyutu - 1) / 2; y < ResimYuksekligi - (SablonBoyutu - 1) / 2; y++)
                {
                    //Şablon bölgesi (çekirdek matris) içindeki pikselleri tarıyor.
                    int k = 0;
                    for (i = -((SablonBoyutu - 1) / 2); i <= (SablonBoyutu - 1) / 2; i++)
                    {
                        for (j = -((SablonBoyutu - 1) / 2); j <= (SablonBoyutu - 1) / 2; j++)
                        {
                            OkunanRenk = islem.GetPixel(x + i, y + j);
                            R[k] = OkunanRenk.R;
                            G[k] = OkunanRenk.G;
                            B[k] = OkunanRenk.B;
                            Gri[k] = Convert.ToInt16(R[k] * 0.299 + G[k] * 0.587 + B[k] * 0.114);
                            k++;
                        }
                    }
                    //Gri tona göre sıralama yapıyor. Aynı anda üç rengide değiştiriyor.
                    int GeciciSayi = 0;
                    for (i = 0; i < ElemanSayisi; i++)
                    {
                        for (j = i + 1; j < ElemanSayisi; j++)
                        {
                            if (Gri[j] < Gri[i])
                            {
                                GeciciSayi = Gri[i];
                                Gri[i] = Gri[j];
                                Gri[j] = GeciciSayi;
                                GeciciSayi = R[i];
                                R[i] = R[j];
                                R[j] = GeciciSayi;
                                GeciciSayi = G[i];
                                G[i] = G[j];
                                G[j] = GeciciSayi;
                                GeciciSayi = B[i];
                                B[i] = B[j];
                                B[j] = GeciciSayi;
                            }
                        }
                    }
                    //Sıralama sonrası ortadaki değeri çıkış resminin piksel değeri olarak atıyor.
                    med.SetPixel(x, y, Color.FromArgb(R[(ElemanSayisi - 1) / 2], G[(ElemanSayisi - 1) /2], B[(ElemanSayisi - 1) / 2]));
                }
            }
            
        }

        private void orHistogramHesapla(Bitmap imge)//orijinal görüntünün histogramı
        {
            ArrayList DiziPiksel = new ArrayList();
            int OrtalamaRenk = 0;
            Color OkunanRenk;
            Bitmap GirisResmi; //Histogram için giriş resmi gri-ton olmalıdır.
            GirisResmi = new Bitmap(imge);
            int ResimGenisligi = GirisResmi.Width; //GirisResmi global tanımlandı.
            int ResimYuksekligi = GirisResmi.Height;
            for (int x = 0; x < GirisResmi.Width; x++)
            {
                for (int y = 0; y < GirisResmi.Height; y++)
                {
                    OkunanRenk = GirisResmi.GetPixel(x, y);
                    OrtalamaRenk = (int)(OkunanRenk.R + OkunanRenk.G + OkunanRenk.B) / 3; //Griton resimde üç kanal  rengi aynı değere sahiptir.
                    DiziPiksel.Add(OrtalamaRenk); //Resimdeki tüm noktaları diziye atıyor. 
                }
            }
            int[] DiziPikselSayilari = new int[256];
            for (int r = 0; r <= 255; r++) //256 tane renk tonu için dönecek.
            {
                int PikselSayisi = 0;
                for (int s = 0; s < DiziPiksel.Count; s++) //resimdeki piksel sayısınca dönecek. 
                {
                    if (r == Convert.ToInt16(DiziPiksel[s]))
                        PikselSayisi++;
                }
                DiziPikselSayilari[r] = PikselSayisi;
            }
            //Değerleri listbox'a ekliyor. 
            int RenkMaksPikselSayisi = 0; //Grafikte y eksenini ölçeklerken kullanılacak. 
            for (int k = 0; k <= 255; k++)
            {
                listBox1.Items.Add("Renk:" + k + "=" + DiziPikselSayilari[k]);
                //Maksimum piksel sayısını bulmaya çalışıyor.
                if (DiziPikselSayilari[k] > RenkMaksPikselSayisi)
                {
                    RenkMaksPikselSayisi = DiziPikselSayilari[k];
                }
            }
            //Grafiği çiziyor. 
            Graphics CizimAlani;
            Pen Kalem1 = new Pen(System.Drawing.Color.Yellow, 1);
            Pen Kalem2 = new Pen(System.Drawing.Color.Red, 1);
            CizimAlani = pictureBox4.CreateGraphics();
            pictureBox4.Refresh();
            int GrafikYuksekligi = 300;
            double OlcekY = RenkMaksPikselSayisi / GrafikYuksekligi;
            double OlcekX = 1.5;
            int X_kaydirma = 10;
            for (int x = 0; x <= 255; x++)
            {
                if (x % 50 == 0)
                    CizimAlani.DrawLine(Kalem2, (int)(X_kaydirma + x * OlcekX),
                   GrafikYuksekligi, (int)(X_kaydirma + x * OlcekX), 0);
                CizimAlani.DrawLine(Kalem1, (int)(X_kaydirma + x * OlcekX), GrafikYuksekligi,
               (int)(X_kaydirma + x * OlcekX), (GrafikYuksekligi - (int)(DiziPikselSayilari[x] / OlcekY)));
                //Dikey kırmızı çizgiler.

            }
            textBox1.Text = "Maks.Piks=" + RenkMaksPikselSayisi.ToString();
        }

        private void secBtn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathLbl.Text = openFileDialog1.FileName;
                imgepath = openFileDialog1.FileName;
                orijinal = new Bitmap(imgepath);
                pictureBox1.Image = orijinal;
                orHistogramHesapla(orijinal);
            }
        }

        private void sonucBtn_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Grayscale")
            {
                rgb2gray(orijinal);
                foto = grayscale;
                pictureBox2.Image = foto;
                histogramHesapla(foto);
            }

            if (comboBox1.SelectedItem == "Threshold")
            {
                thresholding(orijinal);
                foto = thresholded;
                pictureBox2.Image= foto;
                histogramHesapla(foto);
            }

            if (comboBox1.SelectedItem == "Negative")
            {
                makeNeg(orijinal);
                foto = negative;
                pictureBox2.Image = foto;
                histogramHesapla(foto);
            }

            if (comboBox1.SelectedItem == "Gray Negative")
            {
                rgb2gray(orijinal);
                makeGrayNeg();
                foto = grayNegative;
                pictureBox2.Image = foto;
                histogramHesapla(foto);
            }

            if (comboBox1.SelectedItem=="Kontrast Germe")
            {
                kontrastgerme(orijinal);
                foto = kontrastGerilme;
                pictureBox2.Image = foto;
                histogramHesapla(foto);
            }

            if (comboBox1.SelectedItem == "Gaussian")
            {
                gauss(orijinal);
                foto = gaussian;
                pictureBox2.Image = foto;
                histogramHesapla(foto);
            }

            if (comboBox1.SelectedItem == "Ortalama")
            {
                ortalama(orijinal);
                foto = orta;
                pictureBox2.Image = foto;
                histogramHesapla(foto);
            }

            if (comboBox1.SelectedItem == "Medyan")
            {
                medyan(orijinal);
                foto = med;
                pictureBox2.Image = foto;
                histogramHesapla(foto);
            }

            if (comboBox1.SelectedItem == "Laplas")
            {
                laplas(orijinal);
                foto = laplased;
                pictureBox2.Image = foto;
                histogramHesapla(foto);
            }

            if (comboBox1.SelectedItem == "Sobel")
            {
                rgb2gray(orijinal);
                sobel(grayscale);
                foto = sobelxy;
                pictureBox2.Image = foto;
                histogramHesapla(foto);
            }

            if (comboBox1.SelectedItem == "Prewitt")
            {
                prewitt(orijinal);
                foto = prewitted;
                pictureBox2.Image = foto;
                histogramHesapla(foto);
            }

            if (comboBox1.SelectedItem == "Döndür")
            {
                dondur(orijinal);
                foto = dndr;
                pictureBox2.Image = foto;
                histogramHesapla(foto);
            }

            if (comboBox1.SelectedItem == "Aynalama Dikey")
            {
                aynalamaDikey(orijinal);
                foto = aynaD;
                pictureBox2.Image = foto;
                histogramHesapla(foto);
            }

            if (comboBox1.SelectedItem == "Aynalama Yatay")
            {
                aynalamaYatay(orijinal);
                foto = aynaY;
                pictureBox2.Image = foto;
                histogramHesapla(foto);
            }

            if (comboBox1.SelectedItem == "Öteleme")
            {
                oteleme(orijinal);
                foto = otelen;
                pictureBox2.Image = foto;
                histogramHesapla(foto);
            }

            if (comboBox1.SelectedItem == "Zoom Out")
            {
                zoomOut(orijinal);
                foto = zoomO;
                pictureBox2.Image = foto;
                histogramHesapla(foto);
            }

            if (comboBox1.SelectedItem == "Zoom In")
            {
                zoomIn(orijinal);
                foto = zoomI;
                pictureBox2.Image = foto;
                histogramHesapla(foto);
            }

            if (comboBox1.SelectedItem == "Netleştirme")
            {
                netlestirme(orijinal);
                foto = netlestir;
                pictureBox2.Image = foto;
                histogramHesapla(foto);
            }

            if (comboBox1.SelectedItem == "Prespektif")
            {
                prespektif(orijinal);
                foto = prespekt;
                pictureBox2.Image = foto;
                histogramHesapla(foto);
            }

            if (comboBox1.SelectedItem == "Parlaklık")
            {
                ParlakligiDegistir(orijinal);
                foto = parlaklik;
                pictureBox2.Image = foto;
                histogramHesapla(foto);
            }

            if (comboBox1.SelectedItem == "Kontrast")
            {
                kontrast(orijinal);
                foto = kontrastImg;
                pictureBox2.Image = foto;
                histogramHesapla(foto);
            }
        }
    }
}