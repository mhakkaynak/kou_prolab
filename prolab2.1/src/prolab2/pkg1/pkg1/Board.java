package prolab2.pkg1.pkg1;

import java.awt.Graphics;
import java.awt.Image;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyAdapter;
import java.awt.event.KeyEvent;
import java.util.ArrayList;
import java.util.Random;

import javax.swing.*;

public class Board extends JPanel implements ActionListener {

    private final Timer timer;
    private final Map m;
    private final Oyuncu oyuncu;
    private final ArrayList<Dusman> dusman = new ArrayList<>(2);
    private final int[][] map;
    private final Lokasyon oyuncuLokasyon;
    private final ArrayList<Obje> altinList = new ArrayList<>(5);
    private Obje mantar;
    private ArrayList<Lokasyon> dusmanLokasyon = new ArrayList<>(2);
    private final Lokasyon sirineLokasyon = new Lokasyon(7, 12);
    private Dusman gargamel = new Gargamel(2, "Gargamel", "Dusman", 2, 15);
    private Dusman azman = new Azman(3, "Azman", "Dusman", 1, 5);
    Random random = new Random();
    private final int[][] mapClone;
    private int altinSuresi = 0;
    private int altinDurmaSuresi = 0;
    private int mantarSuresi = 0;
    private final ArrayList<int[][]> enKisaYolList = new ArrayList<>(2);
    private int mantarDurmaSuresi = 0;
    private final int satir = 11;
    private final int sutun = 13;
    private ArrayList<Lokasyon> ilkLokasyon = new ArrayList();
    private final int cimenSayisi;

    public Board(Oyuncu oyuncu) {
        this.m = new Map();
        this.oyuncu = oyuncu;

        this.m.getDusman().forEach((d) -> {
            if ("Gargamel".equals(d)) {
                this.dusman.add(gargamel);

            } else {
                this.dusman.add(azman);

            }
        });
        m.getDusmanLokasyon().forEach((dl) -> {
            if (null != dl) {
                switch (dl) {
                    case "A":
                        this.dusmanLokasyon.add(new Lokasyon(0, 3));
                        this.ilkLokasyon.add(new Lokasyon(0, 3));
                        break;
                    case "B":
                        this.dusmanLokasyon.add(new Lokasyon(0, 10));
                        this.ilkLokasyon.add(new Lokasyon(0, 10));
                        break;
                    case "C":
                        this.dusmanLokasyon.add(new Lokasyon(5, 0));
                        this.ilkLokasyon.add(new Lokasyon(5, 0));
                        break;
                    case "D":
                        this.dusmanLokasyon.add(new Lokasyon(10, 3));
                        this.ilkLokasyon.add(new Lokasyon(10, 3));
                        break;
                    default:
                        break;
                }
            }
        });
        addKeyListener(new AI());
        setFocusable(true);
        this.timer = new Timer(25, this);
        this.timer.start();
        this.map = m.getMap();
        this.mapClone = map.clone();
        this.oyuncuLokasyon = new Lokasyon(5, 6);
        this.cimenSayisi = getCimenSayisi();

    }

    @Override
    public void actionPerformed(ActionEvent e) {
        repaint();
    }

    @Override
    public void paint(Graphics g) {
        super.paint(g);
        for (int x = 0; x < satir; x++) {
            for (int y = 0; y < sutun; y++) {
                if (this.map[x][y] != 0) {
                    g.drawImage(this.m.getGrass(), y * 32, x * 32, null);
                } else {
                    g.drawImage(this.m.getWall(), y * 32, x * 32, null);
                }
                if (!this.enKisaYolList.isEmpty()) {
                    int count = 0;
                    for (int[][] enKisaYol : this.enKisaYolList) {
                        for (int i = dusman.get(count).getIlerleme(); i < enKisaYol.length; i++) {
                            if (enKisaYol[i][0] == x && enKisaYol[i][1] == y) {
                                g.drawImage(this.m.getyGrass(), y * 32, x * 32, null);
                            }
                        }
                        count++;
                    }
                }
            }
        }
        Image gargamelResim = new ImageIcon("src\\images\\gargamel.png").getImage();
        Image azmanResim = new ImageIcon("src\\images\\cat.png").getImage();
        Image sirineResim = new ImageIcon("src\\images\\sirine.png").getImage();
        Image gozlukluSirinResim = new ImageIcon("src\\images\\smurf2.png").getImage();
        Image tembelSirinResim = new ImageIcon("src\\images\\smurf1.png").getImage();

        mantarOlustur(g);
        altinOlustur(g);

        if ("Gozluklu Sirin".equals(this.oyuncu.getKarakterAd())) {
            g.drawImage(gozlukluSirinResim, this.oyuncuLokasyon.getY() * 32, this.oyuncuLokasyon.getX() * 32, null);
        } else {
            g.drawImage(tembelSirinResim, this.oyuncuLokasyon.getY() * 32, this.oyuncuLokasyon.getX() * 32, null);
        }

        for (int i = 0; i < dusman.size(); i++) {
            if ("Gargamel".equals(dusman.get(i).getKarakterAd())) {
                g.drawImage(gargamelResim, this.dusmanLokasyon.get(i).getY() * 32, this.dusmanLokasyon.get(i).getX() * 32, null);
            } else if ("Azman".equals(dusman.get(i).getKarakterAd())) {
                g.drawImage(azmanResim, this.dusmanLokasyon.get(i).getY() * 32, this.dusmanLokasyon.get(i).getX() * 32, null);
            }
        }
        g.drawImage(sirineResim, sirineLokasyon.getY() * 32, sirineLokasyon.getX() * 32, null);
        oyuncu.puanGoster(g);
    }

    private void mantarOlustur(Graphics g) {
        Image mantarResim = new ImageIcon("src\\images\\mushroom.png").getImage();
        this.mantarSuresi += this.timer.getDelay();
        if ((this.mantarSuresi >= random.nextInt(20) * 1000) && this.mantar == null) {
            Lokasyon mantarLokasyon;
            while (true) {
                mantarLokasyon = new Lokasyon(random.nextInt(satir), random.nextInt(sutun));
                if (this.map[mantarLokasyon.getX()][mantarLokasyon.getY()] != 0 && (mantarLokasyon.getX() != this.oyuncuLokasyon.getX() && mantarLokasyon.getY() != this.oyuncuLokasyon.getY())) {
                    break;
                }
            }
            this.mantar = new Mantar(7000, 50, mantarLokasyon);
        }
        if (this.mantar != null) {
            this.mantarDurmaSuresi += this.timer.getDelay();
            g.drawImage(mantarResim, this.mantar.getLokasyon().getY() * 32, this.mantar.getLokasyon().getX() * 32, null);
            if (this.mantarDurmaSuresi >= this.mantar.getDurmaSSuresi()) {
                this.mantar = null;
                this.mantarSuresi = 0;
                this.mantarDurmaSuresi = 0;
            }
        }
    }

    private void altinOlustur(Graphics g) {
        Image altimResim = new ImageIcon("src\\images\\coin.png").getImage();

        this.altinSuresi += this.timer.getDelay();
        if ((this.altinSuresi >= random.nextInt(10) * 1000) && this.altinList.isEmpty()) {
            Lokasyon altinLokasyon;
            for (int i = 0; i < 5; i++) {
                while (true) {
                    altinLokasyon = new Lokasyon(random.nextInt(this.satir), random.nextInt(sutun));
                    if (this.map[altinLokasyon.getX()][altinLokasyon.getY()] != 0 && (altinLokasyon.getX() != this.oyuncuLokasyon.getX() && altinLokasyon.getY() != this.oyuncuLokasyon.getY())) {
                        this.altinList.add(new Altin(5, 5000, 5, altinLokasyon));
                        break;
                    }
                }
            }
        }
        if (!this.altinList.isEmpty()) {
            this.altinDurmaSuresi += this.timer.getDelay();
            this.altinList.forEach((a) -> {
                g.drawImage(altimResim, a.getLokasyon().getY() * 32, a.getLokasyon().getX() * 32, null);
            });
            if (this.altinDurmaSuresi >= this.altinList.get(0).getDurmaSSuresi()) {
                this.altinList.clear();
                this.altinSuresi = 0;
                this.altinDurmaSuresi = 0;
            }
        }
    }

    private int getCimenSayisi() {
        int count = 0;
        for (int k = 0; k < satir - 1; k++) {
            for (int j = 0; j < sutun - 1; j++) {
                if (map[k][j] != 0) {
                    count++;
                }
            }
        }
        return count;
    }

    public class AI extends KeyAdapter {

        @Override
        public void keyPressed(KeyEvent e) {
            int keycode = e.getKeyCode();

            boolean control = true;

            matrisHazilrama(1);
            if (keycode == KeyEvent.VK_UP) {
                if ((oyuncuLokasyon.getX() - oyuncu.getIlerleme()) + 1 != 0) {
                    if (map[oyuncuLokasyon.getX() - oyuncu.getIlerleme()][oyuncuLokasyon.getY()] == 1 && map[oyuncuLokasyon.getX() - 1][oyuncuLokasyon.getY()] == 1) {
                        map[oyuncuLokasyon.getX()][oyuncuLokasyon.getY()] = 1;
                        oyuncuLokasyon.setX(oyuncuLokasyon.getX() - oyuncu.getIlerleme());
                    }
                }
                control = false;
            }
            if (keycode == KeyEvent.VK_DOWN) {
                if (oyuncuLokasyon.getX() != satir - oyuncu.getIlerleme()) {
                    if (map[oyuncuLokasyon.getX() + oyuncu.getIlerleme()][oyuncuLokasyon.getY()] == 1 && map[oyuncuLokasyon.getX() + 1][oyuncuLokasyon.getY()] == 1) {
                        map[oyuncuLokasyon.getX()][oyuncuLokasyon.getY()] = 1;
                        oyuncuLokasyon.setX(oyuncuLokasyon.getX() + oyuncu.getIlerleme());
                    }
                }
                control = false;
            }
            if (keycode == KeyEvent.VK_LEFT) {
                if ((oyuncuLokasyon.getY() - oyuncu.getIlerleme()) + 1 != 0) {
                    if (map[oyuncuLokasyon.getX()][oyuncuLokasyon.getY() - oyuncu.getIlerleme()] == 1 && map[oyuncuLokasyon.getX()][oyuncuLokasyon.getY() - 1] == 1) {
                        map[oyuncuLokasyon.getX()][oyuncuLokasyon.getY()] = 1;
                        oyuncuLokasyon.setY(oyuncuLokasyon.getY() - oyuncu.getIlerleme());
                    }
                }
                control = false;
            }
            if (keycode == KeyEvent.VK_RIGHT) {
                if (oyuncuLokasyon.getX() == sirineLokasyon.getX() && oyuncuLokasyon.getY() + 1 == sirineLokasyon.getY()) {
                    oyuncuLokasyon.setX(sirineLokasyon.getX());
                    oyuncuLokasyon.setY(sirineLokasyon.getY());
                } else {
                    if (oyuncuLokasyon.getY() != sutun - oyuncu.getIlerleme()) {
                        if (map[oyuncuLokasyon.getX()][oyuncuLokasyon.getY() + oyuncu.getIlerleme()] == 1 && map[oyuncuLokasyon.getX()][oyuncuLokasyon.getY() + 1] == 1) {
                            map[oyuncuLokasyon.getX()][oyuncuLokasyon.getY()] = 1;
                            oyuncuLokasyon.setY(oyuncuLokasyon.getY() + oyuncu.getIlerleme());
                        }
                    }
                }
                control = false;
            }

            if (mantar != null) {
                if (mantar.getLokasyon().getX() == oyuncuLokasyon.getX() && mantar.getLokasyon().getY() == oyuncuLokasyon.getY()) {
                    oyuncu.setScore(oyuncu.getScore() + mantar.getPuan());
                    mantar = null;
                }
            }
            if (!altinList.isEmpty()) {
                for (int i = 0; i < altinList.size(); i++) {
                    if (altinList.get(i).getLokasyon().getX() == oyuncuLokasyon.getX() && altinList.get(i).getLokasyon().getY() == oyuncuLokasyon.getY()) {
                        oyuncu.setScore(oyuncu.getScore() + altinList.get(i).getPuan());
                        altinList.remove(i);
                    }
                }
            }
            enKisaYolList.clear();
            if (oyuncuLokasyon.getX() == sirineLokasyon.getX() && oyuncuLokasyon.getY() == sirineLokasyon.getY()) {
                JOptionPane.showMessageDialog(null, "KAZANDINIZ\nSCORE: " + oyuncu.getScore(), "Message", JOptionPane.ERROR_MESSAGE);
            } else {
                for (int i = 0; i < dusman.size(); i++) {
                    matrisHazilrama(Integer.MAX_VALUE);
                    if (!control) {
                        map[oyuncuLokasyon.getX()][oyuncuLokasyon.getY()] = 100;
                        map[dusmanLokasyon.get(i).getX()][dusmanLokasyon.get(i).getY()] = 100;
                        int[][] enKisaYol = dusman.get(i).enKisaYol(map, dusmanLokasyon.get(i), oyuncuLokasyon, cimenSayisi, satir, sutun);
                        enKisaYolList.add(i, enKisaYol);
                        if (enKisaYol != null) {
                            int count = 0;
                            for (int[] j : enKisaYol) {
                                if (count != 0) {
                                    mapClone[j[0]][j[1]] = 100;
                                }
                                count++;
                            }
                            if (enKisaYol.length > dusman.get(i).getIlerleme()) {
                                dusmanLokasyon.get(i).setX(enKisaYol[dusman.get(i).getIlerleme()][0]);
                                dusmanLokasyon.get(i).setY(enKisaYol[dusman.get(i).getIlerleme()][1]);
                            }
                            if (enKisaYol.length <= dusman.get(i).getIlerleme() || dusmanLokasyon.get(i).getX() == oyuncuLokasyon.getX() && dusmanLokasyon.get(i).getY() == oyuncuLokasyon.getY()) {
                                oyuncu.setScore(oyuncu.getScore() - dusman.get(i).getPuan());
                                if (oyuncu.getScore() <= 0) {
                                    JOptionPane.showMessageDialog(null, "KAZANAMADINIZ", "Message", JOptionPane.ERROR_MESSAGE);
                                } else {
                                    dusmanLokasyon.set(i, new Lokasyon(ilkLokasyon.get(i).getX(), ilkLokasyon.get(i).getY()));
                                }
                            }
                        }
                    }
                }
            }
        }

        private void matrisHazilrama(int value) {
            for (int k = 0; k < satir; k++) {
                for (int j = 0; j < sutun; j++) {
                    if (map[k][j] != 0) {
                        map[k][j] = value;
                    }
                }
            }
        }
    }
}
