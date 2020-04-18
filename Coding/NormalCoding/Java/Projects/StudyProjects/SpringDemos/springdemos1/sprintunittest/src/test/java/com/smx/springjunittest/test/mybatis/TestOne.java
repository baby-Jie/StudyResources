package com.smx.springjunittest.test.mybatis;

import org.junit.Test;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.text.MessageFormat;

public class TestOne {

    @Test
    public void connectMysql() throws  Exception{

        Class.forName("com.mysql.cj.jdbc.Driver");

        Connection con = DriverManager.getConnection("jdbc:mysql://localhost:3306/test_db?serverTimezone=UTC&useSSL=false", "root", "mysql");

        PreparedStatement preparedStatement = con.prepareStatement("select * from user");

        ResultSet resultSet = preparedStatement.executeQuery();

        while (resultSet.next()){

            String name = resultSet.getString("user_name");
            int age = resultSet.getInt("user_id");
            System.out.println(MessageFormat.format("name:{0}, age:{1}", name, age));
        }
    }
}
