package prolab2.pkg1.pkg1;

public class Karakter {

    private int karakterId;
    private String karakterAd;
    private String karakterTur;
    private int ilerleme;

    public Karakter() {
    }

    public Karakter(int karakterId, String karakterAd, String karakterTur, int ilerleme) {
        this.karakterId = karakterId;
        this.karakterAd = karakterAd;
        this.karakterTur = karakterTur;
        this.ilerleme = ilerleme;
    }

    public int getIlerleme() {
        return ilerleme;
    }

    public void setIlerleme(int ilerleme) {
        this.ilerleme = ilerleme;
    }

    public int getKarakterId() {
        return karakterId;
    }

    public void setKarakterId(int karakterId) {
        this.karakterId = karakterId;
    }

    public String getKarakterAd() {
        return karakterAd;
    }

    public void setKarakterAd(String karakterAd) {
        this.karakterAd = karakterAd;
    }

    public String getKarakterTur() {
        return karakterTur;
    }

    public void setKarakterTur(String karakterTur) {
        this.karakterTur = karakterTur;
    }

    int[][] enKisaYol(int[][] map, Lokasyon dusmanLokasyon, Lokasyon oyuncuLokasyon, int yolSayaci, int satir, int sutun) {
        return map;
    }
}
