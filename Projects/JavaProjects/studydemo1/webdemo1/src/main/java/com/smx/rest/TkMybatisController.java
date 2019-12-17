package com.smx.rest;

import com.smx.model.domain.User;
import com.smx.model.mapper.UserMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import tk.mybatis.mapper.entity.Condition;
import tk.mybatis.mapper.entity.Example;
import tk.mybatis.mapper.util.Sqls;
import tk.mybatis.mapper.weekend.WeekendSqls;

import java.util.List;

@RestController
@RequestMapping("/user")
public class TkMybatisController {

    @Autowired
    private UserMapper userMapper;

    // region query

    // region selectByPrimaryKey 根据主键获取
    @RequestMapping("/selectByPrimaryKey")
    public User selectByPrimaryKey() {

        return userMapper.selectByPrimaryKey(41L);
    }
    // endregion selectByPrimaryKey 根据主键获取

    // region existsWithPrimaryKey 根据主键判断是否存在
    @RequestMapping("/existsWithPrimaryKey")
    public boolean existsWithPrimaryKey() {
        return userMapper.existsWithPrimaryKey(41L);
    }
    // endregion existsWithPrimaryKey 根据主键判断是否存在

    // region selectByExample 根据自定义条件查询
    @RequestMapping("/selectByExample")
    public List<User> selectByExample() {

        Condition condition = new Condition(User.class);
        condition.createCriteria().andEqualTo("userName", "小二王");
        return userMapper.selectByExample(condition);
    }
    // endregion selectByExample 根据自定义条件查询

    // region selectAll 获取所有
    @RequestMapping("/selectAll")
    public List<User> selectAll() {

        return userMapper.selectAll();
    }
    // endregion selectAll 获取所有

    // region select 选择 根据其中不为空的字段作为条件 选择所有符合条件的
    @RequestMapping("/select")
    public List<User> select(User user) {
        return userMapper.select(user);
    }
    // endregion select 选择 根据其中不为空的字段作为条件 选择所有符合条件的

    // endregion query

    // region insert

    // region insert 添加一条记录
    public Integer insert(User user) {
        return userMapper.insert(user);
    }
    // endregion insert 添加一条记录

    // region insertSelective 添加一条记录 null值不作为数据插入
    @RequestMapping("/insertSelective")
    public Integer insertSelective(User user) {

        return userMapper.insertSelective(user);
    }
    // endregion insertSelective

    // endregion insert

    // region delete

    // region deleteByPrimaryKey 根据主键删除
    @RequestMapping("deleteByPrimaryKey/{id}")
    public void deleteByPrimaryKey(@PathVariable("id") Long id) {
        userMapper.deleteByPrimaryKey(id);
    }
    // endregion deleteByPrimaryKey 根据主键删除

    // region deleteByExample 根据自定义条件删除
    @RequestMapping("/deleteByExample")
    public Integer deleteByExample() {

        Condition condition = new Condition(User.class);
        condition.createCriteria().andEqualTo("userName", "smx");
        return userMapper.deleteByExample(condition);
    }
    // endregion deleteByExample 根据自定义条件删除

    // region delete 删除用户 根据其中不为空的字段作为条件 删除所有符合条件的
    @RequestMapping("/delete")
    public Integer delete(User user) {
        return userMapper.delete(user);
    }
    // endregion delete 删除用户 根据其中不为空的字段作为条件 删除所有符合条件的

    // endregion delete

    // region update

    // region updateByPrimaryKey 根据主键更新
    @RequestMapping("/updateByPrimaryKey/{id}")
    public Integer updateByPrimaryKey(User user, @PathVariable("id") Long id) {
        user.setId(id);
        return userMapper.updateByPrimaryKey(user);
    }
    // endregion updateByPrimaryKey 根据主键更新

    // region updateByPrimaryKeySelective 根据主键更新
    @RequestMapping("/updateByPrimaryKeySelective/{id}")
    public Integer updateByPrimaryKeySelective(User user, @PathVariable("id") Long id) {
        user.setId(id);
        return userMapper.updateByPrimaryKeySelective(user);
    }
    // endregion updateByPrimaryKeySelective 根据主键更新

    // region updateByExample 自定义条件更新
    @RequestMapping("/updateByExample")
    public Integer updateByExample(User user) {
        Condition condition = new Condition(User.class);
        condition.createCriteria().andEqualTo("userName", "smx");
        return userMapper.updateByExample(user, condition);
    }
    // endregion updateByExample 自定义条件更新

    // region updateByExampleSelective 自定义条件更新
    @RequestMapping("/updateByExampleSelective")
    public Integer updateByExampleSelective(User user) {
        Condition condition = new Condition(User.class);
        condition.createCriteria().andEqualTo("userName", "smx");
        return userMapper.updateByExampleSelective(user, condition);
    }
    // endregion updateByExampleSelective 自定义条件更新

    // endregion update

    // region Condition or Example

    /**
     * 1. 普通的Example方式（从 and方法开始可以实现动态sql拼接）
     * 2. Criteria方式(可使用criteria完成动态sql拼接)
     * 3. Example.builder 方式（其中where从句中内容可以拿出来进行动态sql拼接）
     * 4. Example.builder + Weekend方式，优势：不用输入属性名，避免数据库有变动或输入错误就会出错
     */

    @RequestMapping("/exampleTest1")
    public List<User> exampleTest1() {
        Condition condition = new Condition(User.class);
        condition.selectProperties("userName", "sex", "address")
                 .and().andEqualTo("sex", "男").andLike("userName", "%王%");
        condition.orderBy("address").desc();
        List<User> users = userMapper.selectByExample(condition);
        return users;
    }

    @RequestMapping("/criteriaTest1")
    public List<User> criteriaTest1() {
        Condition condition = new Condition(User.class);
        // 少了一个and？
        condition.createCriteria().andLike("userName", "%王%");
        condition.orderBy("address").asc();
        List<User> users = userMapper.selectByExample(condition);
        return users;
    }

    @RequestMapping("/builderTest1")
    public List<User> builderTest1() {
        Example condition = Condition.builder(User.class)
                                     .select("userName", "sex", "address").where(Sqls.custom().
                        andLike("userName", "%王%")).orderByDesc("address").build();

        return userMapper.selectByExample(condition);
    }

    @RequestMapping("/weekendTest1")
    public List<User> weekendTest1(){

        WeekendSqls<User> sqls = WeekendSqls.custom();
        sqls = sqls.andEqualTo(User::getSex, "男").andLike(User::getUserName, "%王%");
        return userMapper.selectByExample(Condition.builder(User.class).where(sqls).orderByDesc("address").build());
    }

    // endregion Condition or Example
}
