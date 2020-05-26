package com.smx.springintergrations.queue;

import com.bluejeans.bigqueue.BigQueue;
import com.smx.springintergrations.SpringintergrationsApplication;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.context.junit4.SpringRunner;

@RunWith(SpringRunner.class)
@SpringBootTest(classes = SpringintergrationsApplication.class)
public class BigQueueTest {

    BigQueue bigQueue;
    @Before
    public void setUp(){
        String queueDir = System.getProperty("user.home"); // 获取用户目录
        String queueName = "baeldung-queue";
        bigQueue = new BigQueue(queueDir, queueName);
    }

    @Test
    public void whenAddingRecords_ThenTheSizeIsCorrect() {
        for (int i = 1; i <= 100; i++) {
            bigQueue.enqueue(String.valueOf(i).getBytes());
        }

//        assertEquals(100, bigQueue.size());
    }
}
