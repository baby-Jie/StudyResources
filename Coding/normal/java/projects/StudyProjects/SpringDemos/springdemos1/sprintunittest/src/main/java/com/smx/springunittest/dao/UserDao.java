package com.smx.springunittest.dao;

import com.smx.springunittest.model.User;
import lombok.Data;
import org.apache.commons.dbutils.QueryRunner;
import org.apache.commons.dbutils.handlers.BeanListHandler;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
@Data
public class UserDao {

    @Autowired
    private QueryRunner queryRunner;

    public List<User> findAll() {
        try {
            return queryRunner.query("select * from user", new BeanListHandler<User>(User.class));
        } catch (Exception e) {

            System.out.println(e.getMessage());
            return null;
        }
    }
}
