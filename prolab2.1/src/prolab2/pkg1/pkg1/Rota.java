package prolab2.pkg1.pkg1;

import java.util.Arrays;

public class Rota {

    private Lokasyon lokasyon;
    private int[][] rota;

    public Rota(Lokasyon lokasyon, int[][] rota) {
        this.lokasyon = lokasyon;
        this.rota = rota;
    }

    public Rota() {
    }

    public Lokasyon getLokasyon() {
        return lokasyon;
    }

    public void setLokasyon(Lokasyon lokasyon) {
        this.lokasyon = lokasyon;
    }

    public int[][] getRota() {
        return rota;
    }

    public void setRota(int[][] rota) {
        this.rota = rota;
    }

    public boolean getRoad(String location) {
        for (int[] i : this.rota) {
            if (Arrays.toString(i).equals(location)) {
                return true;
            }
        }
        return false;
    }
}
