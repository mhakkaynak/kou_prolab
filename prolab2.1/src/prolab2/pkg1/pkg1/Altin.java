package prolab2.pkg1.pkg1;

public class Altin extends Obje {

    private int altinSayisi;

    public Altin(int altinSayisi, int durmaSSuresi, int puan, Lokasyon lokasyon) {
        super(durmaSSuresi, puan, lokasyon);
        this.altinSayisi = altinSayisi;
    }

    public int getAltinSayisi() {
        return altinSayisi;
    }

    public void setAltinSayisi(int altinSayisi) {
        this.altinSayisi = altinSayisi;
    }

    public Altin() {
    }
}
