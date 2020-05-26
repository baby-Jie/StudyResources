package com.smx.test;

import org.junit.Test;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.text.MessageFormat;

public class JdbcTest {

    @Test
    public void testJdbc() throws Exception {

        Class.forName("com.mysql.cj.jdbc.Driver");

        Connection connection = DriverManager.getConnection("jdbc:mysql://localhost:3306/test_db?serverTimezone=UTC&useSSL=false", "root", "mysql");

        PreparedStatement preparedStatement = connection.prepareStatement("select * from account");

        ResultSet resultSet = preparedStatement.executeQuery();

        while (resultSet.next()){
            Integer accountId = resultSet.getInt("account_id");
            String accountName = resultSet.getString("account_name");
            Double accountMoney = resultSet.getDouble("account_money");
            String message = MessageFormat.format("id:{0}, name:{1}, money:{2}", accountId, accountName, accountMoney);
            System.out.println(message);
        }
    }
}
