package com.smx.springintergrations.mybatis;

import com.smx.mycommonapi.model.User;
import com.smx.springintergrations.SpringintergrationsApplication;
import com.smx.springintergrations.model.entity.domain.Account;
import com.smx.springintergrations.model.entity.mapper.AccountMapper;
import com.smx.springintergrations.model.entity.mapper.UserMapper;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

import java.util.List;

@RunWith(SpringRunner.class)
@SpringBootTest(classes = SpringintergrationsApplication.class)
public class MyBatisTest {

    @Autowired
    private UserMapper userMapper;

    @Autowired
    private AccountMapper accountMapper;

    @Test
    public void testIfExpressionInXml(){

        List<Account> accountList = accountMapper.testIf("accountId", null);
        System.out.println(accountList);
    }

    @Test
    public void testBind(){
        List<Account> accountList = accountMapper.testBind("account_name", "desc");
        System.out.println(accountList);
    }

    @Test
    public void testConcat(){

        List<Account> accountList = accountMapper.findConcat("mx");
        System.out.println(accountList);
    }

    @Test
    public void testOrderBySqlImport(){
        List<Account> accountList = accountMapper.findSpecificOrderBy("desc");
        System.out.println(accountList);
    }

    @Test
    public void testSpecificSql(){

        String sqlStr = "select account_id as accountId, account_name as accountName from account;";
        List<Account> accountList = accountMapper.findSpecificSql(sqlStr);
        System.out.println(accountList);
    }

    @Test
    public void testSqlImport(){

        Account account = new Account();
//        account.setAccountName("haah' or 1 = 1 or account_name = '1"); // sql注入
//        account.setAccountName("smx' or 1 = 1 or account_name = '1"); // sql注入
        List<Account> accounts = accountMapper.findSpecific(account);

        System.out.println(accounts);
    }

    @Test
    public void testMybatis(){

        List<User> userList = userMapper.findAll();
        System.out.println(userList);
        System.out.println(userMapper == null);
        System.out.println(":yes");
    }

    @Test
    public void testInsert(){
        User user = new User();
        user.setScore(1);
        user.setUserName("smx1");
        user.setUserId(100);
        userMapper.insert(user);
        System.out.println("yes");
    }
}
