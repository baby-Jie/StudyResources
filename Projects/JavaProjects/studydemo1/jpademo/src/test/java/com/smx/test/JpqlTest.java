package com.smx.test;

import com.smx.util.JpaUtil;
import com.smx.util.LogUtil;
import org.junit.After;
import org.junit.Before;
import org.junit.Test;

import javax.persistence.EntityManager;
import javax.persistence.EntityTransaction;
import javax.persistence.Query;
import java.util.List;

public class JpqlTest {

    // region init and destroy and fields
    private EntityManager entityManager;

    private EntityTransaction entityTransaction;

    @Before
    public void init() {
        entityManager = JpaUtil.getEntityManager();
        entityTransaction = entityManager.getTransaction();
        entityTransaction.begin();
    }

    @After
    public void destroy() {
        entityTransaction.commit();
        entityManager.close();
    }
    // endregion

    /**
     * 查询全部
     * jqpl：from cn.itcast.domain.Customer
     * sql：SELECT * FROM cst_customer
     */
    @Test
    public void findAllTest() {

        String jpql = "from CustomerBak";
        Query query = entityManager.createQuery(jpql);
        List list = query.getResultList();

        for (Object o : list) {
            System.out.println(o);
        }
    }

    /**
     * 排序查询： 倒序查询全部客户（根据id倒序）
     * sql：SELECT * FROM cst_customer ORDER BY cust_id DESC
     * jpql：from Customer order by custId desc
     * <p>
     * 进行jpql查询
     * 1.创建query查询对象
     * 2.对参数进行赋值
     * 3.查询，并得到返回结果
     */
    @Test
    public void orderTest() {

        String jpql = "from CustomerBak order by custId desc";
        Query query = entityManager.createQuery(jpql);

        List list = query.getResultList();

        // 这里使用Customer类型就会报错
        for (Object customer : list) {
            LogUtil.RedInfo(customer.toString());
        }
    }

    /**
     * 使用jpql查询，统计客户的总数
     *      sql：SELECT COUNT(cust_id) FROM cst_customer
     *      jpql：select count(custId) from Customer
     */
    @Test
    public void countTest(){

        String jpql = "select count(custId) from CustomerBak";
        Query query = entityManager.createQuery(jpql);
        Object ret = query.getSingleResult();
        LogUtil.RedInfo(ret.toString());
    }

    /**
     * 分页查询
     *      sql：select * from cst_customer limit 0,2
     *      jqpl : from Customer
     */
    @Test
    public void pageTest(){

        String jpql = "from CustomerBak";

        Query query = entityManager.createQuery(jpql);
        // 起始索引
        query.setFirstResult(1);
        // 每页查询的条数
        query.setMaxResults(3);

        List list = query.getResultList();
        for (Object o: list){
            LogUtil.RedInfo(o);
        }
    }

    /**
     * 条件查询
     *     案例：查询客户名称以‘传智播客’开头的客户
     *          sql：SELECT * FROM cst_customer WHERE cust_name LIKE  ?
     *          jpql : from Customer where custName like ?
     *          query.setParameter(0, "industry%"); 已经不再支持了
     */
    @Test
    public void conditionTest(){

        String jpql = "from CustomerBak where custName like ?";
        Query query = entityManager.createQuery(jpql);

        // query parameters (`?`) are no longer supported
//        query.setParameter(0, "industry%");

        List list = query.getResultList();
        for (Object o: list){
            LogUtil.RedInfo(o);
        }
    }

}
