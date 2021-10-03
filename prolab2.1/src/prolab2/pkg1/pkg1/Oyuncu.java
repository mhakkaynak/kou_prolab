package prolab2.pkg1.pkg1;

import java.awt.Graphics;

public class Oyuncu extends Karakter {

    private int score;

    public Oyuncu() {
    }

    public Oyuncu(int karakterId, String karakterAd, String karakterTur, int score, int ilerleme) {
        super(karakterId, karakterAd, karakterTur, ilerleme);
        this.score = score;

    }

    public void puanGoster(Graphics g) {
        g.drawString("Score: " + score, 200, 400);
    }

    public int getScore() {
        return score;
    }

    public void setScore(int score) {
        this.score = score;
    }

}
