install qemu, libvirt, vagrant, vagrant-libvirt,mutate
./host_process.sh

vagrant box add --provider virtualbox srouting/srv6-net-prog
vagrant mutate srouting/srv6-net-prog  libvirt
