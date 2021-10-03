package prolab2.pkg1.pkg1;

import javax.swing.ImageIcon;

import java.awt.Image;
import java.io.File;
import java.io.FileNotFoundException;
import java.util.ArrayList;
import java.util.Scanner;

public class Map {

    private Scanner scanner;
    private final String[] mapRead = new String[11];
    private int[][] map = new int[11][13];
    private Image grass, wall, yGrass;
    private ArrayList<String> dusman = new ArrayList();
    private ArrayList<String> dusmanLokasyon = new ArrayList();

    public Map() {
        ImageIcon img = new ImageIcon("src\\images\\grass.png");
        grass = img.getImage();
        ImageIcon img2 = new ImageIcon("src\\images\\wood.png");
        wall = img2.getImage();
        ImageIcon img3 = new ImageIcon("src\\images\\ygrass.png");
        yGrass = img3.getImage();
        openFile();
        readFile();

    }

    public Image getGrass() {
        return grass;

    }

    public Image getWall() {
        return wall;

    }

    public Image getyGrass() {
        return yGrass;
    }

    public void setyGrass(Image yGrass) {
        this.yGrass = yGrass;
    }

    public ArrayList<String> getDusman() {
        return dusman;
    }

    public void setDusman(ArrayList<String> dusman) {
        this.dusman = dusman;
    }

    public ArrayList<String> getDusmanLokasyon() {
        return dusmanLokasyon;
    }

    public void setDusmanLokasyon(ArrayList<String> dusmanLokasyon) {
        this.dusmanLokasyon = dusmanLokasyon;
    }

    public String getMap(int x, int y) {
        String index = mapRead[y].substring(x, x + 1);
        return index;
    }

    private void readFile() {
        int sayac = 0;
        while (scanner.hasNextLine()) {
            String satir = scanner.nextLine();
            if (satir.charAt(0) == '0' || satir.charAt(0) == '1') {
                mapRead[sayac] = satir;
                sayac++;
            } else {
                if (satir.contains("Gargamel")) {
                    dusman.add("Gargamel");
                } else if (satir.contains("Azman")) {
                    dusman.add("Azman");
                }
                if (satir.contains("Kapi:A")) {
                    dusmanLokasyon.add("A");
                } else if (satir.contains("Kapi:B")) {
                    dusmanLokasyon.add("B");
                } else if (satir.contains("Kapi:C")) {
                    dusmanLokasyon.add("C");
                } else if (satir.contains("Kapi:D")) {
                    dusmanLokasyon.add("D");
                }
            }
        }

        for (int i = 0;
                i < 11; i++) {
            int sayac3 = 0;
            for (int j = 0; j < 25; j++) {
                if (mapRead[i].charAt(j) != '\t') {
                    map[i][sayac3] = Integer.parseInt(mapRead[i].substring(j, j + 1));
                    sayac3++;
                }
            }
        }
    }

    public int[][] getMap() {
        return map;
    }

    public void setMap(int[][] map) {
        this.map = map;
    }

    private void openFile() {
        try {
            scanner = new Scanner(new File("src\\map\\Map.txt"));
        } catch (FileNotFoundException e) {
            System.out.println("Error loading map!");
        }

    }
}
