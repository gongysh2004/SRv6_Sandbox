install qemu, libvirt, vagrant, vagrant-libvirt,mutate
./host_process.sh

vagrant box add --provider virtualbox srouting/srv6-net-prog
vagrant mutate srouting/srv6-net-prog  libvirt
vagrant up
for x in {1..7}; do brctl stp virbr$x off; done
