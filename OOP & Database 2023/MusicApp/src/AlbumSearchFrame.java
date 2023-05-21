import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.util.List;
import java.util.Vector;

public class AlbumSearchFrame extends JFrame{
    private JPanel MusicSearchPanel;
    private JPanel SearchPanel;
    private JPanel firstNameSearchButton;
    private JTextField nameField;
    private JButton nameSearchButton;
    private JTextField authorField;
    private JButton authorButton;
    private JList<String> resultList;
    private JTextField albumNumberField;
    private JButton albumButton;
    private JButton createAlbumButton;


    public AlbumSearchFrame(){
        setContentPane(MusicSearchPanel);
        setSize(700, 500);
        setLocationRelativeTo(null);

        albumButton.addActionListener(new AlbumSearchAction());
        createAlbumButton.addActionListener(new CreateAlbumAction());
        nameSearchButton.addActionListener(new AlbumNameSearchAction());
        authorButton.addActionListener(new AlbumAuthorSearchAction());

        this.setVisible(true);
    }

    class AlbumSearchAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            if(resultList.getSelectedValue() == null){
                JOptionPane.showMessageDialog(null, "Select album first!");
            } else {
                AlbumFrame.albumName = resultList.getSelectedValue();
                new AlbumFrame();
            }
        }
    }

    static class CreateAlbumAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            AlbumFrame.albumName = null;
            new AlbumFrame();
        }
    }

    class AlbumNameSearchAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            if(Queries.isAlbumNameExisting(nameField.getText())){
                AlbumFrame.albumName = nameField.getText();
                new AlbumFrame();
            } else {
                JOptionPane.showMessageDialog(null, "No search result!");
            }
        }
    }

    class AlbumAuthorSearchAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            String authorName = authorField.getText();
            int searchedAuthorId = Queries.getUserIdByName(authorName);

            Vector<String> vector = new Vector<>(Queries.getAlbumByAuthorId(searchedAuthorId));
            resultList.setListData(vector);
            if(vector.size() == 0){
                JOptionPane.showMessageDialog(null, "No search result!");
            }
        }

    }

}
