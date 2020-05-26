package com.smx.test;

import com.mchange.v2.c3p0.ComboPooledDataSource;
import org.junit.Test;

import java.sql.Connection;

public class C3p0Test {

    @Test
    public void testC3p0() throws Exception{

        ComboPooledDataSource dataSource = new ComboPooledDataSource();
        dataSource.setDriverClass("com.mysql.cj.jdbc.Driver");
        dataSource.setJdbcUrl("jdbc:mysql://localhost:3306/test_db?serverTimezone=UTC&useSSL=false");
        dataSource.setUser("root");
        dataSource.setPassword("mysql");

        Connection connection = dataSource.getConnection();

    }
}
