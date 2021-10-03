package prolab2.pkg1.pkg1;

import java.awt.Graphics;

public class GozlukluSirin extends Oyuncu {

    public GozlukluSirin() {

    }

    public GozlukluSirin(int oyuncuId, String oyuncuAd, String oyuncuTur, int score, int ilerleme) {
        super(oyuncuId, oyuncuAd, oyuncuTur, score, ilerleme);

    }

    @Override
    public void puanGoster(Graphics g) {
        super.puanGoster(g);
    }

}
