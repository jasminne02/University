import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.util.List;
import java.util.Vector;

public class ProfilesSearchFrame extends JFrame{
    private JPanel ProfilesSearchPanel;
    private JTextField usernameField;
    private JButton usernameSearchButton;
    private JTextField firstNameField;
    private JTextField lastNameField;
    private JTextField profileNumberField;
    private JButton profileButton;
    private JPanel firstNameSearchButton;
    private JButton lastNameSearchButton;
    private JList<Object> resultList;
    private JButton firstNamSearchButton;

    private final List<String> queriedUsers = new ArrayList<>();

    public ProfilesSearchFrame(){
        setContentPane(ProfilesSearchPanel);
        setSize(700, 500);
        setLocationRelativeTo(null);

        usernameSearchButton.addActionListener(new UsernameSearchAction());
        firstNamSearchButton.addActionListener(new FirstNameSearchAction());
        lastNameSearchButton.addActionListener(new LastNameSearchAction());
        profileButton.addActionListener(new ProfileSearchAction());

        this.setVisible(true);
    }

    class ProfileSearchAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            if(User.isAdmin){
                int numberChosen = Integer.parseInt(profileNumberField.getText());
                ProfileFrame.username = queriedUsers.get(numberChosen-1);
                new ProfileFrame();
            } else {
                JOptionPane.showMessageDialog(null, "You have no permissions to see more info about that user!");
            }
        }
    }

    class UsernameSearchAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            if(Queries.isUserExisting(usernameField.getText())){
                ProfileFrame.username = usernameField.getText();
                new ProfileFrame();
            } else {
                JOptionPane.showMessageDialog(null, "No search result!");
            }
        }
    }

    class FirstNameSearchAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            String firstName = firstNameField.getText();
            List<String> result = getAndParseQueryData(firstName);
            Vector<String> vector = new Vector<>(result);
            resultList.setListData(vector);
            if(vector.size() == 0){
                JOptionPane.showMessageDialog(null, "No search result!");
            }
        }

        private List<String> getAndParseQueryData(String firstName){
            List<String> query = Queries.getUserInfoByFirstName(firstName);
            List<String> finalList = new ArrayList<>();
            int counter = 1;
            queriedUsers.clear();

            for(int i=0; i<query.size(); i+=3){
                String username = query.get(i);
                String lastName = query.get(i+2);

                queriedUsers.add(username);
                String resultString = "Number: " + counter + "  Username: " + username + "  Name: " + firstName + " " + lastName;
                finalList.add(resultString);
            }

            return finalList;
        }
    }

    class LastNameSearchAction implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {
            String lastName = lastNameField.getText();
            List<String> result = getAndParseQueryData(lastName);
            Vector<String> vector = new Vector<>(result);
            resultList.setListData(vector);
            if(vector.size() == 0){
                JOptionPane.showMessageDialog(null, "No search result!");
            }
        }

        private List<String> getAndParseQueryData(String lastName){
            List<String> query = Queries.getUserInfoByLastName(lastName);
            List<String> finalList = new ArrayList<>();
            int counter = 1;
            queriedUsers.clear();

            for(int i=0; i<query.size(); i+=3){
                String username = query.get(i);
                String firstName = query.get(i+1);

                queriedUsers.add(username);
                String resultString = "Number: " + counter + "  Username: " + username + "  Name: " + firstName + " " + lastName;
                finalList.add(resultString);
            }

            return finalList;
        }
    }
}
