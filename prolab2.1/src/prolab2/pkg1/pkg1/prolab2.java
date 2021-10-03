package prolab2.pkg1.pkg1;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;

public class prolab2 extends JFrame {

    public static void main(String[] args) {

        JButton button1 = buttonOlustur(50, 50, 200, 200, new ImageIcon("src\\images\\smurf2.png"), "Gozluklu Sirin");

        JButton button2 = buttonOlustur(300, 50, 200, 200, new ImageIcon("src\\images\\smurf1.png"), "Tembel Sirin");

        JFrame girisFrame = frameOlustur(550, 400, "Giris");
        girisFrame.setLayout(null);

        girisFrame.add(button1);
        girisFrame.add(button2);

        button1.addActionListener((java.awt.event.ActionEvent evt) -> {
            oyunaBasla(new GozlukluSirin(0, "Gozluklu Sirin", "Oyuncu", 20, 2));
            girisFrame.dispose();

        });
        button2.addActionListener((java.awt.event.ActionEvent evt) -> {
            oyunaBasla(new TembelSirin(1, "Tembel Sirin", "Oyuncu", 20, 1));
            girisFrame.dispose();
        });

    }

    private static JButton buttonOlustur(int x, int y, int genislik, int yukseklik, ImageIcon img, String text) {
        JButton button = new JButton();
        button.setBounds(x, y, genislik, yukseklik);
        button.setVisible(true);
        button.setText(text);
        button.setIcon(img);
        button.setFocusable(false);
        return button;
    }

    private static JFrame frameOlustur(int genislik, int yukseklik, String text) {
        JFrame frame = new JFrame();
        frame.setTitle(text);
        frame.setSize(genislik, yukseklik);
        frame.setLocationRelativeTo(null);
        frame.setVisible(true);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        return frame;
    }

    private static void oyunaBasla(Oyuncu oyuncu) {
        JFrame oyunframe = frameOlustur(500, 500, "Smurfs");
        oyunframe.add(new Board(oyuncu));

    }
}
