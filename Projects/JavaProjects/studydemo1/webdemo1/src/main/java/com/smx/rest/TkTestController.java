package com.smx.rest;

import com.smx.model.domain.User;
import com.smx.model.mapper.UserMapper;
import com.smx.util.LogUtil;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import tk.mybatis.mapper.entity.Condition;
import tk.mybatis.mapper.entity.Example;
import tk.mybatis.mapper.util.Sqls;
import tk.mybatis.mapper.weekend.WeekendSqls;

import javax.jws.soap.SOAPBinding;
import java.util.List;

@RestController
public class TkTestController {

    @Autowired
    private UserMapper userMapper;

    @RequestMapping("/select")
    public User select(){

        /**
         * retrieve:
         * selectAll
         * selectByPrimaryKey
         * select
         * selectByExample
         */

        // selectAll
        List<User> userList = userMapper.selectAll();

        User user = userMapper.selectByPrimaryKey(41L);

        User queryUser = new User();
        queryUser.setSex("男");
        userList = userMapper.select(queryUser);

        Condition condition = new Condition(User.class);
        condition.createCriteria().andEqualTo("sex", "女");
        userList = userMapper.selectByExample(condition);

        for (User user1: userList){
            LogUtil.RedInfo(user1);
        }
        return user;
    }

    @RequestMapping("/save")
    public void save(){
        User user = new User();
        user.setUserName("xyj");
        user.setAddress("盐城");
        user.setSex("女");
        userMapper.insert(user);
        userMapper.insertSelective(user);
    }

    @RequestMapping("/delete/{id}")
    public void delete(@PathVariable("id")Long id){

        User user = new User();
        user.setUserName("xyj");
        userMapper.deleteByPrimaryKey(id);
        userMapper.delete(user);
        Condition condition = new Condition(User.class);
        condition.createCriteria().andEqualTo("userName", "smx");
        userMapper.deleteByExample(condition);
    }

    @RequestMapping("/update")
    public void update(){

//        userMapper.updateByPrimaryKey();
//        userMapper.updateByPrimaryKeySelective();
//        userMapper.updateByExample();
//        userMapper.updateByExampleSelective();
    }

    @RequestMapping("/condition")
    public List<User> conditionTest(){

        Condition condition = new Condition(User.class);

        // method 1
        condition.selectProperties("userName", "sex", "id").and().andEqualTo("sex", "男");
        condition.orderBy("id").desc();

        // method 2
        Example example = Condition.builder(User.class).select("userName", "sex").where(Sqls.custom().andEqualTo("sex", "男")).orderBy("id").build();

        // method 3

        WeekendSqls<User> sqls = WeekendSqls.custom();
        sqls.andEqualTo(User::getUserName, "smx");
        Example example2 = Condition.builder(User.class).where(sqls).build();
        List<User> list = userMapper.selectByExample(example2);
        return list;
    }
}
