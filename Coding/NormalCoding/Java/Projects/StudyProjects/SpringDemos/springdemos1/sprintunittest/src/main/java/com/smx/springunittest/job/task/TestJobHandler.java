package com.smx.springunittest.job.task;

import com.xxl.job.core.biz.model.ReturnT;
import com.xxl.job.core.handler.IJobHandler;
import com.xxl.job.core.handler.annotation.JobHandler;
import com.xxl.job.core.log.XxlJobLogger;
import com.xxl.job.core.util.ShardingUtil;
import lombok.extern.slf4j.Slf4j;
import org.springframework.stereotype.Component;

@Component
@JobHandler("testJobHandler")
@Slf4j
public class TestJobHandler extends IJobHandler {

    @Override
    public ReturnT<String> execute(String param) {

        // 分片参数
        ShardingUtil.ShardingVO shardingVO = ShardingUtil.getShardingVo();
        int index = shardingVO.getIndex();
        int total = shardingVO.getTotal();

        // xxl 日志
        XxlJobLogger.log("分片参数：当前分片序号 = {}, 总分片数 = {}, 任务参数 = {}", index, total, param);
        // spring 日志
        log.info("分片参数：当前分片序号 = {}, 总分片数 = {}, 任务参数 = {}", index, total, param);

        log.info("【定时任务】开始，ing...");


        return SUCCESS;
    }
}
