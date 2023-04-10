import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.util.List;

public class MusicSearchFrame extends JFrame{
    private JPanel MusicSearchPanel;
    private JPanel SearchPanel;
    private JPanel firstNameSearchButton;
    private JTextField nameField;
    private JButton nameSearchButton;
    private JTextField genreField;
    private JTextField authorField;
    private JButton genreSearchButton;
    private JButton authorButton;
    private JList<Object> resultList;
    private JTextField musicNumberField;
    private JButton musicButton;
    private JButton createMusicButton;

    private final List<String> queriedMusic = new ArrayList<>();

    public MusicSearchFrame(){
        setContentPane(MusicSearchPanel);
        setSize(700, 500);
        setLocationRelativeTo(null);

        musicButton.addActionListener(new MusicSearchAction());

        this.setVisible(true);
    }

    class MusicSearchAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            int numberChosen = Integer.parseInt(musicNumberField.getText());
            MusicFrame.musicName = queriedMusic.get(numberChosen-1);
            new ProfileFrame();
        }
    }


}
