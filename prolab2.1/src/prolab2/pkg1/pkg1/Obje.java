package prolab2.pkg1.pkg1;

public class Obje {

    private int durmaSuresi;
    private int puan;
    private Lokasyon lokasyon;

    public Obje(int durmaSSuresi, int puan, Lokasyon lokasyon) {
        this.durmaSuresi = durmaSSuresi;
        this.lokasyon = lokasyon;
        this.puan = puan;
    }

    public Obje() {
    }

    public Lokasyon getLokasyon() {
        return lokasyon;
    }

    public void setLokasyon(Lokasyon lokasyon) {
        this.lokasyon = lokasyon;
    }

    public int getPuan() {
        return puan;
    }

    public void setPuan(int puan) {
        this.puan = puan;
    }

    public int getDurmaSSuresi() {
        return durmaSuresi;
    }

    public void setDurmaSSuresi(int durmaSSuresi) {
        this.durmaSuresi = durmaSSuresi;
    }

}
