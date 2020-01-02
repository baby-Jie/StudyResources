package com.smx.dao;


import com.smx.model.LinkMan;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.JpaSpecificationExecutor;

/**
 * 联系人的dao接口
 */
public interface LinkManDao extends JpaRepository<LinkMan,Long>, JpaSpecificationExecutor<LinkMan> {

}
