package com.smx.test.algorithm;

import com.smx.entity.BinaryTree;
import org.junit.Before;
import org.junit.Test;

public class BinaryTreeDemo {

    private BinaryTree binaryTree1;
    private BinaryTree binaryTree2;

    @Before
    public void init() {
        binaryTree1 = new BinaryTree(1);


        binaryTree2 = new BinaryTree(4);
    }

    @Test
    public void isomorphismBinaryTreeTest() {
        boolean isSame = isomorphismBinaryTree(binaryTree1, binaryTree2);

        System.out.println("\033[31;4m" + isSame);

    }

    public boolean isomorphismBinaryTree(BinaryTree root1, BinaryTree root2) {

        if (root1 == null || root2 == null) {

            if (root1 == null && root2 == null) {
                return true;
            }
            return false;
        }

        // 二者都不为null
        if (root1.getValue() != root2.getValue()) {
            return false;
        }

        BinaryTree left1 = root1.getLeft();
        BinaryTree right1 = root1.getRight();
        BinaryTree left2 = root2.getLeft();
        BinaryTree right2 = root2.getRight();

        boolean flag1 = isomorphismBinaryTree(left1, left2) && isomorphismBinaryTree(right1, right2);
        boolean flag2 = isomorphismBinaryTree(left1, right2) && isomorphismBinaryTree(right1, left2);
        return flag1 || flag2;
    }

    @Test
    public void isSameTreeTest() {
        boolean isSame = isSameTree(binaryTree1, binaryTree2);

        System.out.println("\033[31;4m" + isSame);
    }

    private boolean isSameTree(BinaryTree root1, BinaryTree root2) {

        if (root1 == null || root2 == null) {

            if (root1 == null && root2 == null) {
                return true;
            }
            return false;
        }

        // 二者都不为null
        if (root1.getValue() != root2.getValue()) {
            return false;
        }

        return isSameTree(root1.getLeft(), root2.getLeft()) && isSameTree(root1.getRight(), root2.getRight());
    }
}
