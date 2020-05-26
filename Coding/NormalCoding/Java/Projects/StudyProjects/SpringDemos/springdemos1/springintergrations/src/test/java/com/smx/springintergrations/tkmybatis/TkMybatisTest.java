package com.smx.springintergrations.tkmybatis;

import com.smx.springintergrations.SpringintergrationsApplication;
import com.smx.springintergrations.model.entity.domain.Account;
import com.smx.springintergrations.model.entity.domain.CustomerUser;
import com.smx.springintergrations.model.entity.mapper.AccountMapper;
import com.smx.springintergrations.model.entity.mapper.CustomerUserMapper;
import org.assertj.core.util.Lists;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;
import tk.mybatis.mapper.entity.Condition;

import java.util.List;

@RunWith(SpringRunner.class)
@SpringBootTest(classes = SpringintergrationsApplication.class)
public class TkMybatisTest {

    @Autowired
    private CustomerUserMapper customerUserMapper;

    @Autowired
    private AccountMapper accountMapper;

    @Test
    public void testUserMapper(){

        List<CustomerUser> customerUserList =  customerUserMapper.selectAll();
        System.out.println(customerUserList);
    }

    @Test
    public void accountMapper(){

        Account account = new Account();
        account.setAccountId(3);
//        account.setAccountName("smx1");
//        accountMapper.insertSelective(account);
        List<Account> accountList = accountMapper.selectAll();
        System.out.println(accountList);
    }

    @Test
    public void testSelectOne(){

        Condition condition = new Condition(Account.class);
        List<Integer> ids = Lists.newArrayList(1, 2);
        condition.createCriteria().andIn("accountId", ids);
        Account account = accountMapper.selectOneByExample(condition);
        System.out.println(account);

        Account account1 = new Account();
        account1.setAccountId(1);
        List<Account> accountList = accountMapper.selectByIds("1,2"); // 要
        System.out.println(accountList);
    }
}
