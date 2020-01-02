package com.smx.test;

import com.smx.dao.CustomerDao;
import com.smx.model.Customer;
import com.smx.util.LogUtil;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import javax.transaction.Transactional;
import java.util.List;

@RunWith(SpringJUnit4ClassRunner.class) //声明spring提供的单元测试环境
@ContextConfiguration(locations = "classpath:applicationContext.xml")//指定spring容器的配置信息
public class CustomerDaoTest {

    /**
     * 总结：
     * 方法：
     * findOne(id)
     * getOne(id)
     * findAll
     * exists(id)
     * count
     * save(customer) // insert and update(null)
     * delete(id)
     */

    @Autowired
    private CustomerDao customerDao;

    /**
     * 查询所有
     */
    @Test
    public void findAllTest() {

        List<Customer> list = customerDao.findAll();

        for (Customer customer : list) {
            LogUtil.RedInfo(customer);
        }
    }

    /**
     * 查询一个
     */
    @Test
    public void findOneTest(){

        Customer customer = customerDao.findOne(1L);
        LogUtil.RedInfo(customer);
    }


    /**
     * 根据id从数据库查询
     *      @Transactional : 保证getOne正常运行
     *
     *  findOne：
     *      em.find()           :立即加载
     *  getOne：
     *      em.getReference     :延迟加载
     *      * 返回的是一个客户的动态代理对象
     *      * 什么时候用，什么时候查询
     */
    @Test
    @Transactional
    public void getOneTest(){

        Customer customer = customerDao.getOne(1L);
        LogUtil.RedInfo(customer);
    }

    /**
     * 测试统计查询：查询客户的总数量
     * count:统计总条数
     */
    @Test
    public void countTest(){
        Long count = customerDao.count();
        LogUtil.RedInfo("count is:" + count);
    }

    /**
     * 测试：判断id为4的客户是否存在
     *      1. 可以查询以下id为4的客户
     *          如果值为空，代表不存在，如果不为空，代表存在
     *      2. 判断数据库中id为4的客户的数量
     *          如果数量为0，代表不存在，如果大于0，代表存在
     */
    @Test
    public void existTest(){
        boolean flag = customerDao.exists(2L);
        LogUtil.RedInfo("id: 2 exists ?:" + flag);
    }

    @Test
    public void saveTest(){

        Customer customer  = new Customer();
        customer.setCustName("黑马程序员");
        customer.setCustLevel("vip");
        customer.setCustIndustry("it教育");
        customerDao.save(customer);
    }

    /**
     * 更新 注意：没有赋值的全部为null
     */
    @Test
    public void updateTest(){

        Customer customer  = new Customer();
        customer.setCustId(4L);
        customer.setCustName("黑马程序员很厉害");
        customerDao.save(customer);
    }

    /**
     * 删除
     */
    @Test
    public void deleteTest(){

        customerDao.delete(52L);
    }

}
