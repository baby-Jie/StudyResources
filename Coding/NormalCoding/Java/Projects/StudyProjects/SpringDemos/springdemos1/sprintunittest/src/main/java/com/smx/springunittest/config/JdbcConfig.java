package com.smx.springunittest.config;

import com.mchange.v2.c3p0.ComboPooledDataSource;
import lombok.Data;
import org.apache.commons.dbutils.QueryRunner;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.context.annotation.Bean;
import javax.sql.DataSource;


public class JdbcConfig {

    @Value("${jdbc.driver}")
    private String driver;

    @Value("${jdbc.url}")
    private String url;

    @Value("${jdbc.username}")
    private String username;

    @Value("${jdbc.password}")
    private String password;

    @Bean("datasource")
    public DataSource getDataSource() {

        try {
            ComboPooledDataSource ds = new ComboPooledDataSource();
            ds.setDriverClass(driver);
            ds.setJdbcUrl(url);
            ds.setUser(username);
            ds.setPassword(password);
            return ds;
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    @Bean
    public QueryRunner getQueryRunner(@Autowired DataSource dataSource) {
        try {
            QueryRunner queryRunner = new QueryRunner(dataSource);
            return queryRunner;
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

}
