package com.smx.test;

import com.smx.dao.CustomerDao;
import com.smx.model.Customer;
import com.smx.util.LogUtil;
import net.bytebuddy.TypeCache;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.Sort;
import org.springframework.data.jpa.domain.Specification;
import org.springframework.data.repository.config.CustomRepositoryImplementationDetector;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import javax.persistence.criteria.*;
import java.util.List;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations = "classpath:applicationContext.xml")
public class SpecTest {

    @Autowired
    private CustomerDao customerDao;

    /**
     * 根据条件，查询单个对象
     *
     */
    @Test
    public void specTest1(){

        //匿名内部类
        /**
         * 自定义查询条件
         *      1.实现Specification接口（提供泛型：查询的对象类型）
         *      2.实现toPredicate方法（构造查询条件）
         *      3.需要借助方法参数中的两个参数（
         *          root：获取需要查询的对象属性
         *          CriteriaBuilder：构造查询条件的，内部封装了很多的查询条件（模糊匹配，精准匹配）
         *       ）
         *  案例：根据客户名称查询，查询客户名为传智播客的客户
         *          查询条件
         *              1.查询方式
         *                  cb对象
         *              2.比较的属性名称
         *                  root对象
         *
         */
        Specification<Customer> spec = (root, query, cb) -> {
            //1.获取比较的属性
            Path<Object> custName = root.get("custName");
            //2.构造查询条件  ：    select * from cst_customer where cust_name = '传智播客'
            /**
             * 第一个参数：需要比较的属性（path对象）
             * 第二个参数：当前需要比较的取值
             */
            Predicate predicate = cb.equal(custName, "星哥");//进行精准的匹配  （比较的属性，比较的属性的取值）
            return predicate;
        };
        Customer customer = customerDao.findOne(spec);
        if (customer == null){
            LogUtil.RedInfo("customer is null");
        }
        LogUtil.RedInfo(customer);
    }

    /**
     * 多条件查询
     *      案例：根据客户名（传智播客）和客户所属行业查询（it教育）
     *
     */
    @Test
    public void specTest2(){

        Specification<Customer> specification = (root, query, cb)->{

            Path<Object> custName = root.get("custName");
            Path<Object> custIndustry = root.get("custIndustry");
            Predicate p1 = cb.equal(custName, "hello星哥");
            Predicate p2 = cb.equal(custIndustry, "格式工厂1");
            return cb.and(p1, p2);
        };

        Customer customer = customerDao.findOne(specification);

        LogUtil.RedInfo(customer);
    }

    /**
     * 案例：完成根据客户名称的模糊匹配，返回客户列表
     *      客户名称以 ’传智播客‘ 开头
     *
     * equal ：直接的到path对象（属性），然后进行比较即可
     * gt，lt,ge,le,like : 得到path对象，根据path指定比较的参数类型，再去进行比较
     *      指定参数类型：path.as(类型的字节码对象)
     */
    @Test
    public void specTest3(){

        Specification<Customer> specification = (root, query, cb)->{

            Path<Object> custName = root.get("custName");
            return cb.like(custName.as(String.class), "smx%");
        };

        Sort sort = new Sort(Sort.Direction.DESC, "custId");
        List<Customer> customers =  customerDao.findAll(specification, sort);

        for (Customer customer: customers){
            LogUtil.RedInfo(customer);
        }
    }

    /**
     * 分页查询
     *      Specification: 查询条件
     *      Pageable：分页参数
     *          分页参数：查询的页码，每页查询的条数
     *          findAll(Specification,Pageable)：带有条件的分页
     *          findAll(Pageable)：没有条件的分页
     *  返回：Page（springDataJpa为我们封装好的pageBean对象，数据列表，共条数）
     */
    @Test
    public void specTest4(){


        Pageable pageable = new PageRequest(0, 2);

        Page<Customer> page = customerDao.findAll(null, pageable);

        LogUtil.RedInfo(page.getTotalPages());
        LogUtil.RedInfo(page.getTotalElements());
        LogUtil.RedInfo(page.getContent());
    }
}
