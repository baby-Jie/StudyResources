package com.smx.test;

import com.smx.model.Customer;
import com.smx.util.JpaUtil;
import org.hibernate.engine.spi.SessionFactoryImplementor;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import javax.persistence.EntityManager;
import javax.persistence.EntityTransaction;

public class JpaTest1 {

    /**
     *  保存: persist(customer)
     *  查找: find(Customer.class, 1L)
     *  查找（延迟加载）: getReference(Customer.class, 1L)
     *  删除: remove
     *  改、更新: merge
     */

    // region init and destroy and fields
    private EntityManager entityManager;

    private EntityTransaction entityTransaction;

    @Before
    public void init(){
        entityManager = JpaUtil.getEntityManager();
        entityTransaction = entityManager.getTransaction();
        entityTransaction.begin();
    }

    @After
    public void destroy(){
        entityTransaction.commit();
        entityManager.close();
    }
    // endregion

    /**
     * 测试jpa的保存
     * 案例：保存一个客户到数据库中
     * Jpa的操作步骤
     * 1.加载配置文件创建工厂（实体管理器工厂）对象
     * 2.通过实体管理器工厂获取实体管理器
     * 3.获取事务对象，开启事务
     * 4.完成增删改查操作
     * 5.提交事务（回滚事务）
     * 6.释放资源
     */
    @Test
    public void testSave() {

//        SessionFactoryImplementor

//        //1.加载配置文件创建工厂（实体管理器工厂）对象
//        EntityManagerFactory factory = Persistence.createEntityManagerFactory("myJpa");
//        //2.通过实体管理器工厂获取实体管理器
//        EntityManager em = factory.createEntityManager();
        EntityManager em = JpaUtil.getEntityManager();
        //3.获取事务对象，开启事务
        EntityTransaction tx = em.getTransaction(); //获取事务对象
        tx.begin(); // 开启事务

        //4.完成增删改查操作：保存一个客户到数据库中
        Customer customer = new Customer();
        customer.setCustName("星哥");
        customer.setCustIndustry("格式工厂2");

        // 保存
        em.persist(customer);
        // 5. 提交事务
        tx.commit();

        // 6. 释放资源
        em.close();
    }

    /**
     * 根据id查询客户
     *  使用find方法查询：
     *      1.查询的对象就是当前客户对象本身
     *      2.在调用find方法的时候，就会发送sql语句查询数据库
     *
     *  立即加载
     *
     *
     */
    @Test
    public void findById(){
        // 根据主键查询
        EntityManager entityManager = JpaUtil.getEntityManager();
        Customer customer = entityManager.find(Customer.class, 1L);
        System.out.println(customer);
    }

    /**
     * 根据id查询客户
     *      getReference方法
     *          1.获取的对象是一个动态代理对象
     *          2.调用getReference方法不会立即发送sql语句查询数据库
     *              * 当调用查询结果对象的时候，才会发送查询的sql语句：什么时候用，什么时候发送sql语句查询数据库
     *
     * 延迟加载（懒加载）
     *      * 得到的是一个动态代理对象
     *      * 什么时候用，什么使用才会查询
     */
    @Test
    public void getReferenceTest(){
        Customer customer = entityManager.getReference(Customer.class, 1L);
        System.out.println(customer);
    }

    /**
     * 删除客户的案例
     *
     */
    @Test
    public void removeTest(){

        Customer customer = entityManager.find(Customer.class, 1L);
        entityManager.remove(customer);
    }

    /**
     * 更新客户的操作
     *      merge(Object)
     */
    @Test
    public void mergeTest(){

        Customer customer = entityManager.find(Customer.class, 2L);
        customer.setCustName("hello smx");
        entityManager.merge(customer);
    }
}
