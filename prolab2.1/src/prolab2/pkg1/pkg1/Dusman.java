package prolab2.pkg1.pkg1;

import java.util.ArrayList;

public class Dusman extends Karakter {

    private int puan;

    public Dusman() {
    }

    public Dusman(int dusmanId, String dusmanAd, String dusmanTur, int ilerleme, int puan) {
        super(dusmanId, dusmanAd, dusmanTur, ilerleme);
        this.puan = puan;
    }

    public int getPuan() {
        return puan;
    }

    public void setPuan(int puan) {
        this.puan = puan;
    }

    @Override
    int[][] enKisaYol(int[][] map, Lokasyon dusmanLokasyon, Lokasyon oyuncuLokasyon, int yolSayaci, int satir, int sutun) {
        map[dusmanLokasyon.getX()][dusmanLokasyon.getY()] = 0;
        ArrayList<Rota> rota = new ArrayList<>(600);
        Rota yol = new Rota(new Lokasyon(dusmanLokasyon.getX(), dusmanLokasyon.getY()), new int[][]{{dusmanLokasyon.getX(), dusmanLokasyon.getY()}});
        rota.add(yol);
        int sayac = 0;
        boolean control = false;
        int[][] nextStep = new int[100][100];
        while (sayac <= yolSayaci) {
            int x = (int) rota.get(sayac).getLokasyon().getX();
            int y = rota.get(sayac).getLokasyon().getY();
            if (x != satir - 1) {
                if ((map[x + 1][y] > 200 || map[x + 1][y] == 100) && map[x + 1][y] != 0) {
                    map[x + 1][y] = 1 + map[x][y];
                    nextStep = new int[][]{{x + 1, y}};
                    yol = new Rota(new Lokasyon(x + 1, y), matrisBirlestirme(rota.get(sayac).getRota(), nextStep));
                    rota.add(yol);
                    control = true;
                }
            }
            if (x != 0) {
                if ((map[x - 1][y] > 200 || map[x - 1][y] == 100) && map[x - 1][y] != 0) {
                    map[x - 1][y] = 1 + map[x][y];
                    nextStep = new int[][]{{x - 1, y}};
                    yol = new Rota(new Lokasyon(x - 1, y), matrisBirlestirme(rota.get(sayac).getRota(), nextStep));
                    rota.add(yol);
                    control = true;
                }
            }
            if (y != sutun - 1) {
                if ((map[x][y + 1] > 200 || map[x][y + 1] == 100) && map[x][y + 1] != 0) {
                    map[x][y + 1] = 1 + map[x][y];
                    nextStep = new int[][]{{x, y + 1}};
                    yol = new Rota(new Lokasyon(x, y + 1), matrisBirlestirme(rota.get(sayac).getRota(), nextStep));
                    rota.add(yol);
                    control = true;
                }
            }
            if (y != 0) {
                if ((map[x][y - 1] > 200 || map[x][y - 1] == 100) && map[x][y - 1] != 0) {
                    map[x][y - 1] = 1 + map[x][y];
                    nextStep = new int[][]{{x, y - 1}};
                    yol = new Rota(new Lokasyon(x, y - 1), matrisBirlestirme(rota.get(sayac).getRota(), nextStep));
                    rota.add(yol);
                    control = true;
                }
            }
            if (control) {
                sayac++;
            }

        }
        map[dusmanLokasyon.getX()][dusmanLokasyon.getY()] = 100;
        map[oyuncuLokasyon.getX()][oyuncuLokasyon.getY()] = 100;
        for (Rota i : rota) {
            if (i.getRoad("[" + oyuncuLokasyon.getX() + ", " + oyuncuLokasyon.getY() + "]")) {
                int[][] rotaMap = i.getRota();
                rotaMap[0][0] = dusmanLokasyon.getX();
                rotaMap[0][1] = dusmanLokasyon.getY();
                return rotaMap;
            }
        }
        return null;
    }

    private static int[][] matrisBirlestirme(int[][] array1, int[][] array2) {
        int[][] ret = new int[array1.length + array2.length][];
        int i;
        for (i = 0; i < array1.length; i++) {
            ret[i] = array1[i];
        }
        for (int[] ints : array2) {
            ret[i++] = ints;
        }
        return ret;
    }
}
