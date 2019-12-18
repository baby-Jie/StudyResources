package com.smx.test;

import com.smx.dao.CustomerDao;
import com.smx.model.Customer;
import com.smx.util.LogUtil;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.annotation.Rollback;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import javax.transaction.Transactional;
import java.util.Arrays;
import java.util.List;

@RunWith(SpringJUnit4ClassRunner.class) //声明spring提供的单元测试环境
@ContextConfiguration(locations = "classpath:applicationContext.xml")//指定spring容器的配置信息
public class JpqlTest2 {

    @Autowired
    private CustomerDao customerDao;

    /**
     * 根据名字查找客户
     */
    @Test
    public void findByName(){
        Customer customer = customerDao.findJpql("smx2");

        LogUtil.RedInfo(customer);
    }

    /**
     * 根据名字和id查找用户
     */
    @Test
    public void findByNameAndId(){
        Customer customer = customerDao.findByNameAndId("星哥", 1L);

        LogUtil.RedInfo(customer);
    }


    /**
     * 测试jpql的更新操作
     *  * springDataJpa中使用jpql完成 更新/删除操作
     *         * 需要手动添加事务的支持
     *         * 默认会执行结束之后，回滚事务
     *   @Rollback : 设置是否自动回滚
     *          false | true
     */
    @Test
    @Transactional
    @Rollback(value = false)
    public void updateTest(){

        customerDao.updateCustomer("hello星哥", 1L);
    }

    //测试sql查询
    @Test
    public void testFindSql() {
        List<Object[]> list = customerDao.findSql("smx%");
        for(Object [] obj : list) {
            LogUtil.RedInfo(Arrays.toString(obj));
        }
    }

    //测试方法命名规则的查询
    @Test
    public void testNaming() {
        Customer customer = customerDao.findByCustName("smx2");
        LogUtil.RedInfo(customer);
    }

    //测试方法命名规则的查询
    @Test
    public void testFindByCustNameLike() {
        List<Customer> list = customerDao.findByCustNameLike("smx%");
        for (Customer customer : list) {
            LogUtil.RedInfo(customer);
        }
    }

    //测试方法命名规则的查询
    @Test
    public void testFindByCustNameLikeAndCustIndustry() {
        Customer customer = customerDao.findByCustNameLikeAndCustIndustry("smx%", "industry3");
        System.out.println(customer);
    }
}
