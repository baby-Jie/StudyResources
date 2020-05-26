package com.smx.springintergrations.mysql;

import org.junit.Test;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.text.MessageFormat;

public class MySqlTest {

    @Test
    public void testConnect() throws Exception{

      Class.forName("com.mysql.cj.jdbc.Driver");

      Connection connection = DriverManager.getConnection("jdbc:mysql://localhost:3306/test_db?serverTimezone=UTC&useSSL=false", "root", "mysql");
      PreparedStatement preparedStatement = connection.prepareStatement("select * from user");
      ResultSet resultSet =  preparedStatement.executeQuery();

      while (resultSet.next()){
          int user_id = resultSet.getInt("user_id");
          String user_name = resultSet.getString("user_name");

          System.out.println(MessageFormat.format("userName:{0}, userId:{1}", user_name, user_id));
      }
    }
}
